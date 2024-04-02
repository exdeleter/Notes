using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Tag;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Tag;

public class CreateTagHandler : IRequestHandler<CreateTagCommand, Guid>
{
    private readonly IRepository<Models.Entities.Tag, TagDto> _repository;
    private readonly ILogger<CreateTagHandler> _logger;

    public CreateTagHandler(IRepository<Models.Entities.Tag, TagDto> repository, ILogger<CreateTagHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(request.Dto, cancellationToken);
    }
}