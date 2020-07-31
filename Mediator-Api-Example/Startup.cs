using Application.Behavior;
using Application.Handler;
using Application.Service;
using Domain_Example.Entity;
using Domain_Example.Notification.Domain;
using Domain_Example.Repository;
using Domain_Example.Service;
using Domain_Example.Validator;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Memory.Repository;
using System.Reflection;

namespace Mediator_Api_Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Transient
            services.AddMediatR(typeof(PersonCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(PersonNotificationHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            #endregion

            #region Scoped
            services.AddScoped<IRepository<Person>, PersonRepositoryMemory>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();
            #endregion

            services.AddValidatorsFromAssemblyContaining(typeof(CreateUserValidator));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
