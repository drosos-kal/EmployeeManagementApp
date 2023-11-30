﻿using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using EmployeeManagementChallenge.Repository.IRepository;
using EmployeeManagementChallenge.Repository;
using EmployeeManagementChallenge.Services;
using EmployeeManagementChallenge.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementChallenge
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.Add("Skills_CRUD_Update", "CRUD/Update/{Id}", "Views/Skills/CRUD/Update.dothtml");
            config.RouteTable.Add("Employees_CRUD_Update", "Employees/CRUD/Update/{Id}", "Views/Employees/CRUD/Update.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));

        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("bootstrap-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/css/bootstrap.css")
            });
            config.Resources.Register("bootstrap", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/js/bootstrap.min.js"),
                Dependencies = new[] { "bootstrap-css" , "jquery" }
            });
            config.Resources.Register("jquery", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/jquery/jquery.min.js")
            });
            config.Resources.Register("Styles", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/Resources/style.css")
            });
        }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
            options.Services.AddScoped<ISkillRepository, SkillRepository>();
            options.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            options.Services.AddScoped<SkillService>();
            options.Services.AddScoped<EmployeeService>();

        }
    }
}
