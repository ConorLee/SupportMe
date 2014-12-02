namespace SupportMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingIPdatamodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InitialPresentations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Payload = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InitialPresentations");
            DropTable("dbo.Individuals");
        }
    }
}
