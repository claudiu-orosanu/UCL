namespace UCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UCL.MatchPlayer",
                c => new
                    {
                        MatchPlayerId = c.Long(nullable: false, identity: true),
                        MinutesPlayed = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Goals = c.Int(nullable: false),
                        RedCards = c.Int(),
                        YellowCards = c.Int(),
                        PlayerId = c.Long(),
                        MatchId = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.MatchPlayerId)
                .ForeignKey("UCL.Player", t => t.PlayerId)
                .ForeignKey("UCL.Match", t => t.MatchId)
                .Index(t => t.PlayerId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "Nom.Position",
                c => new
                    {
                        PositionId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            AddColumn("UCL.Coach", "TeamId", c => c.Long());
            AddColumn("UCL.Match", "HostId", c => c.Long());
            AddColumn("UCL.Match", "GuestId", c => c.Long());
            AddColumn("UCL.Player", "TeamId", c => c.Long());
            AddColumn("UCL.Player", "CaptainId", c => c.Long());
            AddColumn("UCL.Player", "PositionId", c => c.Long());
            AddColumn("UCL.Stadium", "TeamId", c => c.Long());
            CreateIndex("UCL.Coach", "TeamId");
            CreateIndex("UCL.Match", "HostId");
            CreateIndex("UCL.Match", "GuestId");
            CreateIndex("UCL.Player", "TeamId");
            CreateIndex("UCL.Player", "CaptainId");
            CreateIndex("UCL.Player", "PositionId");
            CreateIndex("UCL.Stadium", "TeamId");
            AddForeignKey("UCL.Coach", "TeamId", "UCL.Team", "TeamId");
            AddForeignKey("UCL.Player", "CaptainId", "UCL.Player", "PlayerId");
            AddForeignKey("UCL.Player", "PositionId", "Nom.Position", "PositionId");
            AddForeignKey("UCL.Match", "HostId", "UCL.Team", "TeamId");
            AddForeignKey("UCL.Match", "GuestId", "UCL.Team", "TeamId");
            AddForeignKey("UCL.Player", "TeamId", "UCL.Team", "TeamId");
            AddForeignKey("UCL.Stadium", "TeamId", "UCL.Team", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("UCL.Stadium", "TeamId", "UCL.Team");
            DropForeignKey("UCL.Player", "TeamId", "UCL.Team");
            DropForeignKey("UCL.Match", "GuestId", "UCL.Team");
            DropForeignKey("UCL.Match", "HostId", "UCL.Team");
            DropForeignKey("UCL.MatchPlayer", "MatchId", "UCL.Match");
            DropForeignKey("UCL.Player", "PositionId", "Nom.Position");
            DropForeignKey("UCL.MatchPlayer", "PlayerId", "UCL.Player");
            DropForeignKey("UCL.Player", "CaptainId", "UCL.Player");
            DropForeignKey("UCL.Coach", "TeamId", "UCL.Team");
            DropIndex("UCL.Stadium", new[] { "TeamId" });
            DropIndex("UCL.Player", new[] { "PositionId" });
            DropIndex("UCL.Player", new[] { "CaptainId" });
            DropIndex("UCL.Player", new[] { "TeamId" });
            DropIndex("UCL.MatchPlayer", new[] { "MatchId" });
            DropIndex("UCL.MatchPlayer", new[] { "PlayerId" });
            DropIndex("UCL.Match", new[] { "GuestId" });
            DropIndex("UCL.Match", new[] { "HostId" });
            DropIndex("UCL.Coach", new[] { "TeamId" });
            DropColumn("UCL.Stadium", "TeamId");
            DropColumn("UCL.Player", "PositionId");
            DropColumn("UCL.Player", "CaptainId");
            DropColumn("UCL.Player", "TeamId");
            DropColumn("UCL.Match", "GuestId");
            DropColumn("UCL.Match", "HostId");
            DropColumn("UCL.Coach", "TeamId");
            DropTable("Nom.Position");
            DropTable("UCL.MatchPlayer");
        }
    }
}
