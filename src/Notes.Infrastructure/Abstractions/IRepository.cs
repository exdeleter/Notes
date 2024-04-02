using Notes.Models.Entities.Base;

namespace Notes.Infrastructure.Abstractions;

/// <summary> Обобщенный репозиторий. </summary>
public interface IRepository<T, TDto>
    where T : BaseEntity 
    where TDto : class
{
    /// <summary> Получить по идентификатору. </summary>
    /// <param name="id">Идентификатор</param>
    public Task<T> GetAsync(Guid id, CancellationToken ct);

    /// <summary> Получить все записи. </summary>
    public Task<List<T>> GetAllAsync(CancellationToken ct);

    /// <summary> Обновить. </summary>
    public Task<T> UpdateAsync(TDto dto, CancellationToken ct);

    /// <summary> Создать. </summary>
    public Task<Guid> CreateAsync(TDto dto, CancellationToken ct);

    /// <summary> Удалить. </summary>
    public Task<Guid> DeleteAsync(TDto dto, CancellationToken ct);
}