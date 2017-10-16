namespace Controlle_de_Senha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataHora_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Passwords", "DataHora", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Passwords", "DataHora", c => c.DateTime(nullable: false));
        }
    }
}
