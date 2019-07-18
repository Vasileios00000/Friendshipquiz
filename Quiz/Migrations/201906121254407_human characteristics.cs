namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humancharacteristics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "Popularity", c => c.Double(nullable: false));
            AddColumn("dbo.Humen", "Hardness", c => c.Double(nullable: false));
            AddColumn("dbo.Humen", "AverageScore", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Humen", "AverageScore");
            DropColumn("dbo.Humen", "Hardness");
            DropColumn("dbo.Humen", "Popularity");
        }
    }
}
