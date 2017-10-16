namespace Controlle_de_Senha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Senha_preferencial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passwords", "Tipo", c => c.String());
            AddColumn("dbo.Passwords", "Preferencial", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Passwords", "Preferencial");
            DropColumn("dbo.Passwords", "Tipo");
        }
    }
}
