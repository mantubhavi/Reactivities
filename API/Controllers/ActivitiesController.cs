using Application.Activities.Quries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseAPIController
{
    private readonly AppDbContext context;
    private readonly IMediator mediator;

    public ActivitiesController(AppDbContext context, IMediator mediator)
    {
        this.context = context;
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetails(string id)
    {
       return await mediator.Send(new GetActivityDetails.Query { Id = id });
    }
}
