var builder =
    WebApplication
        .CreateBuilder(args);

// =====================
// CONTROLADORES
// =====================

builder.Services
    .AddControllers();

// =====================
// CORS
// =====================

builder.Services
    .AddCors(
        options =>
        {
            options.AddPolicy(
                "PermitirTodo",
                policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

var app =
    builder.Build();

// =====================
// CORS
// =====================

app.UseCors(
    "PermitirTodo");

// =====================
// CONTROLADORES
// =====================

app.MapControllers();

app.Run();