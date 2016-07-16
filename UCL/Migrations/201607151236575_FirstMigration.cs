namespace UCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UCL.Coach",
                c => new
                    {
                        CoachId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        StartYear = c.Int(),
                        Type = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CoachId);
            
            CreateTable(
                "UCL.Match",
                c => new
                    {
                        MatchId = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        HostScore = c.Int(nullable: false),
                        GuestScore = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Penalty = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.MatchId);
            
            CreateTable(
                "UCL.Player",
                c => new
                    {
                        PlayerId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        DateOfBirth = c.DateTime(),
                        Nationality = c.String(maxLength: 25),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        StartYear = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "UCL.Stadium",
                c => new
                    {
                        StadiumId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        City = c.String(nullable: false, maxLength: 25),
                        Capacity = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.StadiumId);
            
            CreateTable(
                "UCL.Team",
                c => new
                    {
                        TeamId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Country = c.String(nullable: false, maxLength: 25),
                        FormationYear = c.Int(),
                        Eliminated = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropTable("UCL.Team");
            DropTable("UCL.Stadium");
            DropTable("UCL.Player");
            DropTable("UCL.Match");
            DropTable("UCL.Coach");
        }
    }
}
