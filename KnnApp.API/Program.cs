using FluentValidation.AspNetCore;
using KnnApp.Core.DTOs.Category;
using KnnApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KnnApp.API;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());          //  !!! onemli hisse !!!

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<KnnAppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("BineQesebesi"));
        });

        builder.Services.AddAutoMapper(typeof(Business.Helper.Mapper.AutoMapper));
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());                                                 //  !!! onemli hisse !!!

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
    }

}
