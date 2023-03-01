namespace NoraJitterTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NodelResults : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestSetup", "NoDelayedResults", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestSetup", "NoDelayedResults");
        }
    }
}
