using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Queries.Tag;

/// <summary> Квери для получения <see cref="Note"/>. </summary>
public record GetTagsQuery : IRequest<List<TagDto>>;