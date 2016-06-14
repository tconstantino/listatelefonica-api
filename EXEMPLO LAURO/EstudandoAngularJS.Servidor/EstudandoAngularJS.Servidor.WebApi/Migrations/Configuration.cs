namespace EstudandoAngularJS.Servidor.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EstudandoAngularJS.Servidor.WebApi.Data.Contexto.AngularJSContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EstudandoAngularJS.Servidor.WebApi.Data.Contexto.AngularJSContexto context)
        {            
        }
    }
}
