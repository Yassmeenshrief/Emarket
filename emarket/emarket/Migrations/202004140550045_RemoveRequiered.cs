namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiered : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "name", c => c.String());
            AlterColumn("dbo.Product", "image", c => c.String());
            AlterColumn("dbo.Product", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "image", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "name", c => c.String(nullable: false));
        }
    }
}
