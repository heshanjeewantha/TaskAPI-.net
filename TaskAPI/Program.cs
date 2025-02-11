using TaskAPI.Services.Authors;
using TaskAPI.Services.Todos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register the TodoService as the implementation of ITodoRepository
builder.Services.AddScoped<ITodoRepository, TodoSqlServerService>();
builder.Services.AddScoped<IAuthorRepository, AuthorSqlServerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{ 
 app.UseExceptionHandler(app =>
 {
     app.Run(async context =>
     {
         context.Response.StatusCode = 500;
         await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
     });
 });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();