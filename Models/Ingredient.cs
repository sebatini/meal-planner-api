namespace MealPlannerApi.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public string? IngredientName { get; set; }

    public string? Measurement { get; set; }

}
