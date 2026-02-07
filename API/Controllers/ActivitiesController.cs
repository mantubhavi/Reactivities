using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetails(string id)
    {
        var result = await context.Activities.FindAsync(id);
        
        if(result == null)
        {
            return NotFound();
        }

        return result;
    }
}
