using MealPlannerApi.Models; // Adjust this based on your actual namespace for the DbContext
using Microsoft.EntityFrameworkCore; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the RecipePlannerDbContext with SQL Server
builder.Services.AddDbContext<RecipePlannerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecipePlannerDb")));

// Configure CORS to allow requests from your frontend application
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Add your frontend URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowSpecificOrigin"); // Ensure this is called before UseAuthorization

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();