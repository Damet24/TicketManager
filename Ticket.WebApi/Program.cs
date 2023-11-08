using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ticket.WebApi.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var contentRoot = AppDomain.CurrentDomain.BaseDirectory;
var configuration = new ConfigurationBuilder()
    .SetBasePath(contentRoot)
    .Build();
configuration.ConfigureLogger();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container => { container.RegisterModules(configuration); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();