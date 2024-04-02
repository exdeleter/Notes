using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Notes.Api.Validators;
using Notes.Infrastructure.Commands.Note;
using Notes.Infrastructure.Commands.Reminder;
using Notes.Infrastructure.Commands.Tag;
using Notes.Infrastructure.Queries.Note;
using Notes.Infrastructure.Queries.Reminder;
using Notes.Infrastructure.Queries.Tag;
using Notes.Models.Dtos;

namespace Notes.Api.RouteGroupBuilderExtension;

/// <summary> Класс-расширение. </summary>
public static class RouteExtension
{
    /// <summary> Добавить конечные точки. </summary>
    public static IEndpointRouteBuilder MapServices(this IEndpointRouteBuilder group)
    {
        var noteGroup = group.MapGroup("api/v{v:apiVersion}/function");

        MapNotes(noteGroup);
        MapReminders(noteGroup);
        MapTags(noteGroup);

        return group;
    }

    /// <summary> Добавить конечные точки для заметок. </summary>
    private static void MapNotes(RouteGroupBuilder group)
    {
        group.MapGet("/note/get/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetNoteByIdQuery(id));

            if (result is null)
            {
                return Results.NotFound(result);
            }

            return Results.Ok(result);
        });
        
        group.MapGet("/note/get-all", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetNotesQuery());

            return Results.Ok(result);
        });
        
        group.MapPost("/note/create", async ([FromBody]NoteDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateNoteCommand(dto));

            return Results.Ok(result);
        });
        
        group.MapPost("/note/update", async ([FromBody]NoteDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new UpdateNoteCommand(dto));

            if (result is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        });

        group.MapDelete("/note/delete", async ([FromBody]NoteDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteNoteCommand(dto));

            if (result == default)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        });
    }
    
    /// <summary> Добавить конечные точки для напоминаний. </summary>
    private static void MapReminders(RouteGroupBuilder group)
    {
        group.MapGet("/reminder/get/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetReminderByIdQuery(id));

            if (result is null)
            {
                return Results.NotFound(result);
            }

            return Results.Ok(result);
        });
        
        group.MapGet("/reminder/get-all", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetRemindersQuery());

            return Results.Ok(result);
        });
        
        group.MapPost("/reminder/create", async ([FromBody]ReminderDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateReminderCommand(dto));

            return Results.Ok(result);
        });
        
        group.MapPost("/reminder/update", async ([FromBody]ReminderDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new UpdateReminderCommand(dto));

            if (result is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        });

        group.MapDelete("/reminder/delete", async ([FromBody]ReminderDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteReminderCommand(dto));

            if (result == default)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        });
    }

    /// <summary> Добавить конечные точки для тэгов. </summary>
    private static void MapTags(RouteGroupBuilder group)
    {
        group.MapGet("/tag/get/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetTagByIdQuery(id));

            if (result is null)
            {
                return Results.NotFound(result);
            }

            return Results.Ok(result);
        });

        group.MapGet("/tag/get-all", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetTagsQuery());

            return Results.Ok(result);
        });

        group.MapPost("/tag/create", async ([FromBody]TagDto dto, IMediator mediator) =>
        {
            var validator = new TagValidator();

            await validator.ValidateAndThrowAsync(dto);

            var result = await mediator.Send(new CreateTagCommand(dto));

            return Results.Ok(result);
        });

        group.MapPost("/tag/update", async ([FromBody]TagDto dto, IMediator mediator) =>
        {
            var validator = new TagValidator();

            await validator.ValidateAndThrowAsync(dto);

            var result = await mediator.Send(new UpdateTagCommand(dto));

            if (result is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        });

        group.MapDelete("/tag/delete", async ([FromBody]TagDto dto, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteTagCommand(dto));

            if (result == default)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        });
    }
}