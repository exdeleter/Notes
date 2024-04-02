using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Tag;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Tag;

/// <summary> Обработчик обновления <see cref="Tag"/>. </summary>
public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, TagDto?>
{
    private readonly IRepository<Models.Entities.Tag, TagDto> _repository;
    private readonly ILogger<UpdateTagHandler> _logger;

    public UpdateTagHandler(IRepository<Models.Entities.Tag, TagDto> repository, ILogger<UpdateTagHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<TagDto?> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.Dto, cancellationToken);

        return request.Dto;
    }
}