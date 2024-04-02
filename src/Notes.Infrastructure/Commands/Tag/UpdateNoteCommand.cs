using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Tag;

/// <summary> Команда для обновления <see cref="TagDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record UpdateTagCommand(TagDto Dto) : IRequest<TagDto>;