using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Note;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Note;

/// <summary> Обработчик обновления <see cref="Note"/>. </summary>
public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, NoteDto?>
{
    private readonly IRepository<Models.Entities.Note, NoteDto> _repository;
    private readonly ILogger<UpdateNoteHandler> _logger;

    public UpdateNoteHandler(IRepository<Models.Entities.Note, NoteDto> repository, ILogger<UpdateNoteHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<NoteDto?> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.Dto, cancellationToken);

        return request.Dto;
    }
}