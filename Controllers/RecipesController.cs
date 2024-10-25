using MealPlannerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly RecipePlannerDbContext _context;

    public RecipesController(RecipePlannerDbContext context)
    {
        _context = context;
    }

    // Get all recipes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
    {
        return await _context.Recipes.Include(r => r.Ingredients).ToListAsync();
    }
}
