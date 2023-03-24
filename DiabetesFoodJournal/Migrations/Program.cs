﻿using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

var connectionString = config.GetConnectionString("MyDatabase");

var optionsBuilder = new DbContextOptionsBuilder<sewright22_foodjournalContext>();
optionsBuilder.UseMySql(connectionString, ServerVersion.Create(5, 0, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql));

using var dbContext = new sewright22_foodjournalContext(optionsBuilder.Options);
dbContext.Database.Migrate();