namespace HomeW_14._08._2021_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Task4End : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "MultiplayOrNot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "NumberOfSells", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "NumberOfSells");
            DropColumn("dbo.Games", "MultiplayOrNot");
        }
    }
}
