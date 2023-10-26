namespace Loja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XPTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "XPTO", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "XPTO");
        }
    }
}
