var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.Use(async (context, next) =>
{
    bool perfilOk = context.Request.Headers.TryGetValue("Profile", out var perfil);

    if (!perfilOk)
    {
        context.Response.StatusCode = 400;

        return;
    }

    bool requisicaoAdmin = (
        context.Request.Method == "POST" ||
        context.Request.Method == "PUT" ||
        context.Request.Method == "DELETE"
    );

    if (requisicaoAdmin && perfil != "Admin")
    {
        context.Response.StatusCode = 401;

        return;
    }

    if (context.Request.Method == "GET" &&
        context.Request.Path != "/api/person/" &&
        perfil != "Professor" &&
        perfil != "Admin")
    {
        context.Response.StatusCode = 401;

        return;
    }

    await next.Invoke();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
