using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Queries.Tag;

/// <summary> Квери для получения всех <see cref="Tag"/>. </summary>
public record GetTagByIdQuery(Guid Id) : IRequest<TagDto>;