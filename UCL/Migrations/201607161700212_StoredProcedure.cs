namespace UCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProcedure : DbMigration
    {
        public override void Up()
        {
            Sql(@"IF EXISTS (SELECT * FROM sys.procedures WHERE name='TransferPlayer')
	                DROP PROCEDURE UCL.TransferPlayer
                GO
                CREATE PROCEDURE UCL.TransferPlayer @playerToTransferId bigint, @teamId bigint
                AS
                BEGIN
                DECLARE @NewSalary decimal(10,2)
                DECLARE @NewStartYear int
                DECLARE @NewCaptainId bigint

                SET @NewSalary = (SELECT AVG(p.Salary)
				                  FROM UCL.Team t
				                  INNER JOIN UCL.Player p
				                  ON t.TeamId = p.TeamId
				                  AND t.TeamId = @teamId)

                SET @NewStartYear = (SELECT DATEPART(year,GETDATE()))

                SET @NewCaptainId = (SELECT TOP 1 p.CaptainId
					                 FROM UCL.Team t
					                 INNER JOIN UCL.Player p
					                 ON t.TeamId = p.TeamId
					                 AND t.TeamId = @teamId
					                 AND p.CaptainId IS NOT NULL)

                UPDATE UCL.Player
                SET TeamId = @teamId, 
	                Salary = @NewSalary, 
	                StartYear = @NewStartYear, 
	                CaptainId = @NewCaptainId
                WHERE PlayerId = @playerToTransferId

                END
                GO");
        }
        
        public override void Down()
        {
            Sql(@"IF EXISTS (SELECT * FROM sys.procedures WHERE name='TransferPlayer')
	                DROP PROCEDURE UCL.TransferPlayer
                GO");
        }
    }
}
