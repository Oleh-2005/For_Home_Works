namespace HomeW_WF_Ado_31._08._2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Single(nullable: false));
        }
    }
}
