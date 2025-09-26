
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pokemon.Application;
using Pokemon.Application.Services;
using Pokemon.Domain.Repositories;

namespace Pokemon.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
            
            builder.Services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyReference).Assembly));

            builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

            builder.Services.AddHttpClient<IPokemonDataService, PokemonDataService>();

            builder.Services.AddControllers();
            
            // Swagger UI
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

            app.UseAuthorization();

            var scope = app.Services.CreateScope();
            var pokeService = scope.ServiceProvider.GetRequiredService<IPokemonDataService>();
            pokeService.GetPokemonsAsync();

            app.MapControllers();

            app.Run();
        }
    }
}
