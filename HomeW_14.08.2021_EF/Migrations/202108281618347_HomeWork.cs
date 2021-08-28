 namespace HomeW_14._08._2021_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Studio = c.String(),
                        Stayle = c.String(),
                        Reliase = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
