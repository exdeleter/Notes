using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Note;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Note;

public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly IRepository<Models.Entities.Note, NoteDto> _repository;
    private readonly ILogger<CreateNoteHandler> _logger;

    public CreateNoteHandler(IRepository<Models.Entities.Note, NoteDto> repository, ILogger<CreateNoteHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(request.Dto, cancellationToken);
    }
}