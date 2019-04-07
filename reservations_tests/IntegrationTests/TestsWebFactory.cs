using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using reservations_data;
using reservations_data.Repositories.Reservations;
using reservations_data.Repositories.Rooms;
using reservations_domain.Services.Reservations;
using reservations_tests.IntegrationTests.Model;
using reservations_web.Models.Messages;
using reservations_web.Models.Rooms.Factories;

namespace reservations_tests.IntegrationTests
{
    public class TestsWebFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();
 
                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContextPool<ReservationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                
                services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                services.AddScoped<IRoomRepository, RoomRepository>();
                services.AddScoped<IReservationRepository, ReservationRepository>();
                services.AddScoped<IReservationsService, ReservationsService>();
                services.AddSingleton<IRoomsViewModelFactory, RoomsViewModelFactory>();
                services.AddScoped<IMessagesService, MessagesService>();

 
                // Build the service provider.
                var sp = services.BuildServiceProvider();
 
                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ReservationDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<TestsWebFactory<TStartup>>>();
 
                    // Ensure the database is created.
                    db.Database.EnsureCreated();
 
                    try
                    {
                        // Seed the database with test data.
                        TestDbInitializer.Initialize(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}