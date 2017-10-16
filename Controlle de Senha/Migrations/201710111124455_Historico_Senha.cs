namespace Controlle_de_Senha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Historico_Senha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricoSenhas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Senha = c.String(),
                        Guiche = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoricoSenhas");
        }
    }
}
