using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess;
using ManagementSystem.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureAutofacContainer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
        options.UseNpgsql(
            builder.Configuration.GetConnectionString(Context.DbName),
            x => x.MigrationsHistoryTable("__EFMigrationsHistory")));

var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName is not null).ToArray();

builder.Services.AddValidatorsFromAssemblies(assemblies);
builder.Services.AddFluentValidationAutoValidation();

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
