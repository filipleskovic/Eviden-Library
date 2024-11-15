using Autofac;
using Autofac.Extensions.DependencyInjection;
using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Library.Repository;
using Library.Repository.Common;
using Library.Services;
using Library.Services.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-QVGJ8RS\\MSSQLSERVER915;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;");
}
);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<BookAuthorService>().As<IBookAuthorService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<GenreService>().As<IGenreService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();


    containerBuilder.RegisterType<BookAuthorRepository>().As<IBookAuthorRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();


});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
