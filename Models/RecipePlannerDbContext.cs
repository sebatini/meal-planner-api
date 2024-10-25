using Microsoft.EntityFrameworkCore;

namespace MealPlannerApi.Models;

public partial class RecipePlannerDbContext : DbContext
{
    public RecipePlannerDbContext()
    {
    }

    public RecipePlannerDbContext(DbContextOptions<RecipePlannerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RecipePlannerDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25A82475143");

            entity.Property(e => e.IngredientId).ValueGeneratedNever();
            entity.Property(e => e.IngredientName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Measurement)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__FDD988B0D2182711");

            entity.Property(e => e.RecipeId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Directions).HasColumnType("text");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
