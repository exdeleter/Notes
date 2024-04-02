using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Database;
using Notes.Infrastructure.Abstractions;
using Notes.Models.Dtos;
using Notes.Models.Entities;

namespace Notes.Infrastructure.Repositories;

/// <summary> Репозиторий для <see cref="Tag"/>. </summary>
public class TagRepository : IRepository<Tag, TagDto>
{
    private readonly NotesContext _dbContext;
    private readonly IValidator<TagDto> _validator;

    public TagRepository(NotesContext dbContext, IValidator<TagDto> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    /// <inheritdoc />
    public async Task<Tag> GetAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    /// <inheritdoc />
    public async Task<List<Tag>> GetAllAsync(CancellationToken ct)
    {
        return await _dbContext.Tags.ToListAsync(ct);
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(TagDto dto, CancellationToken ct)
    {
        await _validator.ValidateAndThrowAsync(dto, ct);

        var entity = new Tag
        {
            Name = dto.Name
        };

        await _dbContext.AddAsync(entity, ct);

        await _dbContext.SaveChangesAsync(ct);

        return entity.Id;
    }

    /// <inheritdoc />
    public async Task<Tag> UpdateAsync(TagDto dto, CancellationToken ct)
    {
        await _validator.ValidateAndThrowAsync(dto, ct);

        var entity = await GetAsync(dto.Id, ct);

        if (entity is null)
        {
            return null;
        }

        entity.Name = dto.Name;
        
        _dbContext.Tags.Update(entity);

        await _dbContext.SaveChangesAsync(ct);

        return entity;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(TagDto dto, CancellationToken ct)
    {
        var entity = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == dto.Id, ct);

        if (entity is null)
        {
            return default;
        }

        if (await _dbContext.Notes.AnyAsync(x => x.Tags.Contains(entity), ct))
        {
            throw new Exception("К данному тегу привязаны заметки.");
        }

        if (await _dbContext.Reminders.AnyAsync(x => x.Tags.Contains(entity), ct))
        {
            throw new Exception("К данному тегу привязаны напоминания.");
        }

        _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(ct);

        return dto.Id;
    }
}