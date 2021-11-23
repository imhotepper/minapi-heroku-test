var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{    
    c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
});


var app = builder.Build();

if (app.Environment.IsDevelopment()){
     app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
}

app.MapGet("/", () => "Up and running...");
app.MapGet("/{id:int}", (int id) => $"Getting data forId:{id}");
app.MapPost("/todos",( TodoModel model) => {
   //Validation with minimal validation
    return Results.Created("",model);
});
app.Run();


record TodoModel(int Id, String Title, bool IsCompleted=false);