﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace DPS.WebApp.Tests.Config
{
    public class LojaAppFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {

        #region Código Legado

        // Deixei comentado para manter a base histórica, o código comentado é compativel até .NET 5

        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.UseStartup<TProgram>();
        //    builder.UseEnvironment("Testing");
        //}

        #endregion

        // .NET 6 em diante:

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            return base.CreateHost(builder);
        }
    }
}