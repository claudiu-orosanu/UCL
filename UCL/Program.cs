using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCL.Model;
using UCL.UCL;

namespace UCL
{
    class Program
    {
        static void Main(string[] args)
        {
            //DbFunctions.ShowPlayersWithTeam();
            //Console.WriteLine("--------------------\n");

            //DbFunctions.PlayersWhoScoredMostGoals();
            //Console.WriteLine("--------------------\n");

            //DbFunctions.StadiumsWithMostMatches();
            //Console.WriteLine("--------------------\n");

            //DbFunctions.PlayersWhoHaveRatingOver90();
            //Console.WriteLine("--------------------\n");

            ////Adaugam echipa AS Roma
            //List<Stadium> stadiums = new List<Stadium>() { new Stadium { Name = "Stadio Olimpico", City = "Rome", Capacity = 70000 } };
            //List<Coach> coaches = new List<Coach>() { new Coach { FirstName = "Luciano", LastName = "Spalletti", Type = 1 } };
            //List<Player> players = new List<Player>() { new Player { FirstName = "Franceso", LastName = "Totti", StartYear = 1992, Available = true } };
            //DbFunctions.AddTeam("AS Roma", "Italy", 1927, stadiums, coaches, players);



            //Console.WriteLine("\n\n");
            ////Adaugam o dubla (tur-retur) intre Real Madrid si Bayern
            ////adauga turul Real Madrid - Bayern, rezultat 4:1
            //DbFunctions.AddMatch(new DateTime(2016, 07, 16), 4, 1, 1, false, 1, 3);
            //Console.WriteLine("\n\n");
            ////adauga returul Bayern - Real Madrid, rezultat 3:3
            //DbFunctions.AddMatch(new DateTime(2016, 07, 19), 3, 3, 2, false, 3, 1);



            //Console.WriteLine("\n\n");
            ////adauga legatura dintre Gareth Bale si meciul Bayern - Real (care ar trebui sa aiba MatchId = 8)
            //DbFunctions.AddMatchPlayer(90, 96, 2, 0, 1, 3, 8);
            //Console.WriteLine("\n");
            ////adauga legatura dintre Robert Lewandowski si meciul Bayern - Real
            //DbFunctions.AddMatchPlayer(90, 89, 2, 0, 1, 22, 8);
            //Console.WriteLine("\n\n");



            //Console.WriteLine("\n\n");
            ////procedura stocata transfera un jucator la o anumita echipa, salariul acestuia e egal cu media salariilor din acea echipa
            ////transferam pe Mario Gotze de la bayern la real madrid
            //DbFunctions.ExecuteTransferProcedure(23, 1);


            //Console.WriteLine("\n\n");
            ////sterge echipa cu id-ul 3 (bayern)
            //DbFunctions.DeleteTeamById(3);
            //Console.WriteLine("\n");
            //DbFunctions.ShowTeams();

            Console.ReadKey();
        }
    }
}
