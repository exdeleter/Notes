using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Queries.Tag;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Tag;

/// <summary> Обработчик получения <see cref="Tag"/>. </summary>
public class GetTagsHandler : IRequestHandler<GetTagsQuery, List<TagDto>>
{
    private readonly IRepository<Models.Entities.Tag, TagDto> _repository;
    private readonly ILogger<GetTagsQuery> _logger;

    public GetTagsHandler(IRepository<Models.Entities.Tag, TagDto> repository, ILogger<GetTagsQuery> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<List<TagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        var notes = await _repository.GetAllAsync(cancellationToken);

        var listDto = notes.Select(x => new TagDto { Id = x.Id, Name = x.Name }).ToList();

        return listDto;
    }
}