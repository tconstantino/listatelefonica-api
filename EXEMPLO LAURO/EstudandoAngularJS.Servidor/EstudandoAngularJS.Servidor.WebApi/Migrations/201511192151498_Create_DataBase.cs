namespace EstudandoAngularJS.Servidor.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCategoria = c.Int(nullable: false),
                        Nome = c.String(),
                        Codigo = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.IDCategoria, cascadeDelete: true)
                .Index(t => t.IDCategoria);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDOperadora = c.Int(nullable: false),
                        IDFundo = c.Int(nullable: false),
                        Nome = c.String(),
                        Telefone = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fundo", t => t.IDFundo, cascadeDelete: true)
                .ForeignKey("dbo.Operadora", t => t.IDOperadora, cascadeDelete: true)
                .Index(t => t.IDOperadora)
                .Index(t => t.IDFundo);
            
            CreateTable(
                "dbo.Fundo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cor = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operadora", "IDCategoria", "dbo.Categoria");
            DropForeignKey("dbo.Contato", "IDOperadora", "dbo.Operadora");
            DropForeignKey("dbo.Contato", "IDFundo", "dbo.Fundo");
            DropIndex("dbo.Contato", new[] { "IDFundo" });
            DropIndex("dbo.Contato", new[] { "IDOperadora" });
            DropIndex("dbo.Operadora", new[] { "IDCategoria" });
            DropTable("dbo.Fundo");
            DropTable("dbo.Contato");
            DropTable("dbo.Operadora");
            DropTable("dbo.Categoria");
        }
    }
}
