using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Services;
using WorkerService1;

var options = new WebApplicationOptions
{
    ContentRootPath = AppContext.BaseDirectory,
    Args = args,
    ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName
};

var builder = WebApplication.CreateBuilder(options);

builder.Host.UseWindowsService();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>(options =>
{
    string conStr = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(conStr, builder =>
    {
        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    });
});
builder.Services.AddControllers();

builder.Services.AddScoped<IButtonKeyboardService, ButtonKeyboardService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();