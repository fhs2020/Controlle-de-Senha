namespace Controlle_de_Senha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passwords", "DataHora", c => c.DateTime(nullable: false));
            AddColumn("dbo.Passwords", "Guiche", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Passwords", "Guiche");
            DropColumn("dbo.Passwords", "DataHora");
        }
    }
}
