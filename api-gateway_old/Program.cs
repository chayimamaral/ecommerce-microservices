var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async context =>
{
  // Repassa requisição para microserviço de estoque
  await context.Response.WriteAsJsonAsync("Produtos endpoint");
});

app.MapPost("/orders", async context =>
{
  // Repassa requisição para microserviço de vendas
  await Task.CompletedTask;
});

app.Run();

