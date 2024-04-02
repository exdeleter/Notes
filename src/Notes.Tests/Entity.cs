using Notes.Infrastructure.Abstractions;
using Notes.Models.Entities.Base;

namespace Tests;

/// <summary> Сущность для тестирования. </summary>
public class Entity : BaseEntity
{
    /// <summary> Наименование. </summary>
    public string Name { get; set; }
}

/// <summary> Модель для тестирования. </summary>
public class EntityDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}

public class GetEntityByIdHandler 
{
    private readonly IRepository<Entity, EntityDto> _repository;

    public GetEntityByIdHandler(IRepository<Entity, EntityDto> repository)
    {
        _repository = repository;
    }

    public async Task<EntityDto?> Handle(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(id, cancellationToken);

        if (entity == null)
        {
            return default;
        }

        return new EntityDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}

public class GetEntitiesHandler
{
    private readonly IRepository<Entity, EntityDto> _repository;

    public GetEntitiesHandler(IRepository<Entity, EntityDto> repository)
    {
        _repository = repository;
    }

    public async Task<List<EntityDto>> Handle(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);

        var dtos = entities.Select(x => new EntityDto
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();

        return dtos;
    }
}

/// <summary> Обработчик обновления <see cref="Entity"/>. </summary>
public class UpdateEntityHandler
{
    private readonly IRepository<Entity, EntityDto> _repository;

    public UpdateEntityHandler(IRepository<Entity, EntityDto> repository)
    {
        _repository = repository;
    }

    public async Task<EntityDto> Handle(EntityDto dto, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(dto, cancellationToken);

        return dto;
    }
}

/// <summary> Обработчик удаления <see cref="Entity"/>. </summary>
public class DeleteEntityHandler
{
    private readonly IRepository<Entity, EntityDto> _repository;

    public DeleteEntityHandler(IRepository<Entity, EntityDto> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(EntityDto dto, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(dto, cancellationToken);

        return dto.Id;
    }
}
