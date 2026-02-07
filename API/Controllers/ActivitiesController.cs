using Application.Activities.Quries;
using Domain;
using MediatR;
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
       return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }
}
