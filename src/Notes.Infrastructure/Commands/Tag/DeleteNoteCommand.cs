using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Tag;

/// <summary> Команда для удаления <see cref="TagDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record DeleteTagCommand(TagDto Dto) : IRequest<Guid>;