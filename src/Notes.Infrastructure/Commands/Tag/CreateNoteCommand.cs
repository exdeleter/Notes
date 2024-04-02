using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Tag;

/// <summary> Команда для создания <see cref="TagDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record CreateTagCommand(TagDto Dto) : IRequest<Guid>;