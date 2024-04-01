var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Maths/Operation/List", GetAllOperations);

app.Run();

static async Task<IResult> GetAllOperations()
{
    var operations = new List<string>
    {
        "Plus",
        "Division",
        "Multiplication",
        "Subtraction",
    };
    
    return TypedResults.Ok(operations);
}