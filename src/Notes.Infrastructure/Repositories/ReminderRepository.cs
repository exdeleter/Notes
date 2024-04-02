using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Database;
using Notes.Infrastructure.Abstractions;
using Notes.Models.Dtos;
using Notes.Models.Entities;

namespace Notes.Infrastructure.Repositories;

/// <summary> Репозиторий для <see cref="Reminder"/>. </summary>
public class ReminderRepository : IRepository<Reminder, ReminderDto>
{
    private readonly NotesContext _dbContext;
    private readonly IValidator<ReminderDto> _validator;

    public ReminderRepository(NotesContext dbContext, IValidator<ReminderDto> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    /// <inheritdoc />
    public async Task<Reminder> GetAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext.Reminders.Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    /// <inheritdoc />
    public async Task<List<Reminder>> GetAllAsync(CancellationToken ct)
    {
        return await _dbContext.Reminders.Include(x => x.Tags).ToListAsync(ct);
    }
    
    /// <inheritdoc />
    public async Task<Guid> CreateAsync(ReminderDto dto, CancellationToken ct)
    {
        await _validator.ValidateAndThrowAsync(dto, ct);

        var entity = new Reminder
        {
            Header = dto.Header,
            Content = dto.Content,
            NotifyDate = dto.NotifyDate,
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
    public async Task<Reminder> UpdateAsync(ReminderDto dto, CancellationToken ct)
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

        _dbContext.Reminders.Update(entity);

        await _dbContext.SaveChangesAsync(ct);

        return entity;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(ReminderDto dto, CancellationToken ct)
    {
        var entity = await _dbContext.Reminders.FirstOrDefaultAsync(x => x.Id == dto.Id, ct);

        if (entity is null)
        {
            return default;
        }
        
        _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(ct);

        return dto.Id;
    }
}