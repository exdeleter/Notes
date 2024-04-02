using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Note;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Note;

public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, Guid>
{
    private readonly IRepository<Models.Entities.Note, NoteDto> _repository;
    private readonly ILogger<DeleteNoteHandler> _logger;

    public DeleteNoteHandler(IRepository<Models.Entities.Note, NoteDto> repository, ILogger<DeleteNoteHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Dto, cancellationToken);
        
        return request.Dto.Id;
    }
}