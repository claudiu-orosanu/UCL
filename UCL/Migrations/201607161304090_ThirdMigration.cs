namespace UCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("UCL.MatchPlayer", new[] { "PlayerId" });
            DropIndex("UCL.MatchPlayer", new[] { "MatchId" });
            DropIndex("UCL.Stadium", new[] { "TeamId" });
            AlterColumn("UCL.Player", "Salary", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("Nom.Position", "Name", c => c.String(maxLength: 150));
            CreateIndex("UCL.MatchPlayer", new[] { "PlayerId", "MatchId" }, unique: true, name: "UX_PlayerIdAndMatchId");
            CreateIndex("UCL.Player", "Nationality");
            CreateIndex("UCL.Stadium", "TeamId", unique: true, name: "UX_Team");
        }
        
        public override void Down()
        {
            DropIndex("UCL.Stadium", "UX_Team");
            DropIndex("UCL.Player", new[] { "Nationality" });
            DropIndex("UCL.MatchPlayer", "UX_PlayerIdAndMatchId");
            AlterColumn("Nom.Position", "Name", c => c.String());
            AlterColumn("UCL.Player", "Salary", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("UCL.Stadium", "TeamId");
            CreateIndex("UCL.MatchPlayer", "MatchId");
            CreateIndex("UCL.MatchPlayer", "PlayerId");
        }
    }
}
