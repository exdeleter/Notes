using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Queries.Tag;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Tag;

/// <summary> Обработчик получения <see cref="Tag"/> по идентификатору.</summary>
public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, TagDto?>
{
    private readonly IRepository<Models.Entities.Tag, TagDto> _repository;
    private readonly ILogger<GetTagByIdHandler> _logger;

    public GetTagByIdHandler(IRepository<Models.Entities.Tag, TagDto> repository, ILogger<GetTagByIdHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<TagDto?> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            _logger.LogInformation("Entity with {Id} is not found!", request.Id);
            return default;
        }

        return new TagDto { Name = entity.Name };
    }
}