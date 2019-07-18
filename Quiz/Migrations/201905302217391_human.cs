namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class human : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Humen");
            RenameColumn(table: "dbo.Questions", name: "person_Id", newName: "human_Id");
            RenameColumn(table: "dbo.Scores", name: "PersonId", newName: "HumanId");
            RenameIndex(table: "dbo.Questions", name: "IX_person_Id", newName: "IX_human_Id");
            RenameIndex(table: "dbo.Scores", name: "IX_PersonId", newName: "IX_HumanId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Scores", name: "IX_HumanId", newName: "IX_PersonId");
            RenameIndex(table: "dbo.Questions", name: "IX_human_Id", newName: "IX_person_Id");
            RenameColumn(table: "dbo.Scores", name: "HumanId", newName: "PersonId");
            RenameColumn(table: "dbo.Questions", name: "human_Id", newName: "person_Id");
            RenameTable(name: "dbo.Humen", newName: "People");
        }
    }
}
