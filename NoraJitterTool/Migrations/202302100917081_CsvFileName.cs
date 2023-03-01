namespace NoraJitterTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CsvFileName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Delays",
                c => new
                    {
                        DelaysId = c.Int(nullable: false, identity: true),
                        Delay = c.Int(nullable: false),
                        TimeBetweenSamples = c.Int(nullable: false),
                        TestSetupId = c.Int(nullable: false),
                        SampleNumber = c.String(maxLength: 50),
                        SampleDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OpcServerTimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.DelaysId)
                .ForeignKey("dbo.TestSetup", t => t.TestSetupId, cascadeDelete: true)
                .Index(t => t.TestSetupId);
            
            CreateTable(
                "dbo.TestSetup",
                c => new
                    {
                        TestSetupId = c.Int(nullable: false, identity: true),
                        NoraVersion = c.String(nullable: false),
                        TestTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Comment = c.String(),
                        CsvFileName = c.String(),
                        ExcludeFromSummary = c.Boolean(nullable: false),
                        PlatformVersion = c.String(nullable: false, maxLength: 50),
                        TestSystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestSetupId)
                .ForeignKey("dbo.TestSystem", t => t.TestSystemId, cascadeDelete: true)
                .Index(t => t.TestSystemId);
            
            CreateTable(
                "dbo.TestSystem",
                c => new
                    {
                        TestSystemId = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                        ChassisId = c.Decimal(nullable: false, precision: 20, scale: 0),
                        SystemName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TestSystemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestSetup", "TestSystemId", "dbo.TestSystem");
            DropForeignKey("dbo.Delays", "TestSetupId", "dbo.TestSetup");
            DropIndex("dbo.TestSetup", new[] { "TestSystemId" });
            DropIndex("dbo.Delays", new[] { "TestSetupId" });
            DropTable("dbo.TestSystem");
            DropTable("dbo.TestSetup");
            DropTable("dbo.Delays");
        }
    }
}
