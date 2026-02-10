using Application.Activities.Commands;
using Application.Activities.DTOs;
using Application.Activities.Quries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseAPIController
{
    private readonly AppDbContext context;

    public ActivitiesController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetails(string id)
    {
        return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(CreateActivityDTO activity)
    {
        return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDTO = activity }));
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(EditActivityDTO activity)
    {
        return HandleResult(await Mediator.Send(new EditActivity.Command { ActivityDTO = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
    }
}
