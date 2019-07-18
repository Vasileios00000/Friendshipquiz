namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class features : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "Difficulty", c => c.Double(nullable: false));
            AddColumn("dbo.Scores", "Difficulty", c => c.Int(nullable: false));
            DropColumn("dbo.Humen", "Hardness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Humen", "Hardness", c => c.Double(nullable: false));
            DropColumn("dbo.Scores", "Difficulty");
            DropColumn("dbo.Humen", "Difficulty");
        }
    }
}
