using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Database;
using Notes.Infrastructure.Abstractions;
using Notes.Models.Dtos;
using Notes.Models.Entities;

namespace Notes.Infrastructure.Repositories;

/// <summary> Репозиторий для <see cref="Note"/>. </summary>
public class NoteRepository : IRepository<Note, NoteDto>
{
    private readonly NotesContext _dbContext;
    private readonly IValidator<NoteDto> _validator;

    public NoteRepository(NotesContext dbContext, IValidator<NoteDto> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    /// <inheritdoc />
    public async Task<Note> GetAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext.Notes.Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    /// <inheritdoc />
    public async Task<List<Note>> GetAllAsync(CancellationToken ct)
    {
        return await _dbContext.Notes.Include(x => x.Tags).ToListAsync(ct);
    }
    
    /// <inheritdoc />
    public async Task<Guid> CreateAsync(NoteDto dto, CancellationToken ct)
    {
        await _validator.ValidateAndThrowAsync(dto, ct);

        var entity = new Note
        {
            Header = dto.Header,
            Content = dto.Content,
            Tags = new List<Tag>()
        };

        if (dto.Tags is not null)
        {
            foreach (var tagDto in dto.Tags)
            {
                var existingTag = await _dbContext.Tags.FindAsync(tagDto.Id);

                if (existingTag != null)
                {
                    entity.Tags.Add(existingTag);
                }
                else
                {
                    throw new Exception("Данного тега не существует.");
                }
            }
        }

        await _dbContext.AddAsync(entity, ct);

        await _dbContext.SaveChangesAsync(ct);

        return entity.Id;
    }

    /// <inheritdoc />
    public async Task<Note> UpdateAsync(NoteDto dto, CancellationToken ct)
    {
        await _validator.ValidateAndThrowAsync(dto, ct);

        var entity = await GetAsync(dto.Id, ct);

        if (entity is null)
        {
            return null;
        }

        entity.Header = dto.Header;
        entity.Content = dto.Content;

        if (dto.Tags is not null)
        {
            foreach (var tagDto in dto.Tags)
            {
                var existingTag = await _dbContext.Tags.FindAsync(tagDto.Id);

                if (existingTag != null)
                {
                    entity.Tags.Add(existingTag);
                }
                else
                {
                    throw new Exception("Данного тега не существует.");
                }
            }
        }

        _dbContext.Notes.Update(entity);

        await _dbContext.SaveChangesAsync(ct);

        return entity;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(NoteDto dto, CancellationToken ct)
    {
        var entity = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == dto.Id, ct);

        if (entity is null)
        {
            return default;
        }
        
        _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(ct);

        return dto.Id;
    }
}