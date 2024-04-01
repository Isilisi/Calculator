using System.Xml;
using Calculator.Core;

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
app.MapPost("/Maths/Evaluate/Xml", EvaluateXml);

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

static async Task<IResult> EvaluateXml(string xmlString = """
                                                          <?xml version="1.0" encoding="UTF-8"?>
                                                          <Maths>
                                                              <Operation ID="Plus">
                                                                  <Value>2</Value>
                                                                  <Value>3</Value>
                                                                  <Operation ID="Multiplication">
                                                                      <Value>4</Value>
                                                                      <Value>5</Value>
                                                                  </Operation>
                                                              </Operation>
                                                          </Maths>
                                                          """)
{
    try
    {
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlString);
        var xmlParser = new XmlParser();
        var expression = xmlParser.Parse(xmlDocument);
        var result = expression.Evaluate();
        return TypedResults.Ok(result);
    }
    catch (Exception e)
    {
        return TypedResults.BadRequest("Invalid input format");
    }
}