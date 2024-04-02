using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Tag;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Tag;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Guid>
{
    private readonly IRepository<Models.Entities.Tag, TagDto> _repository;
    private readonly ILogger<DeleteTagHandler> _logger;

    public DeleteTagHandler(IRepository<Models.Entities.Tag, TagDto> repository, ILogger<DeleteTagHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Dto, cancellationToken);
        
        return request.Dto.Id;
    }
}