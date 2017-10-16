namespace Controlle_de_Senha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Existe_senha_preferencial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passwords", "NumSenhaPreferencial", c => c.Int(nullable: false));
            AddColumn("dbo.Passwords", "ExisteSenhaPreferencial", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Passwords", "ExisteSenhaPreferencial");
            DropColumn("dbo.Passwords", "NumSenhaPreferencial");
        }
    }
}
