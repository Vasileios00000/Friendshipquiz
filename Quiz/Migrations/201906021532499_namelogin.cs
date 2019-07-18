namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namelogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
