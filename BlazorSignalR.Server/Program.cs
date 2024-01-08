using BlazorSignalR.Server.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
var app = builder.Build();

//builder.Services.AddRazorComponents()
//    .AddInteractiveWebAssemblyComponents();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chathub");

app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();
