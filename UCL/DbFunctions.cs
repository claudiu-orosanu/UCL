using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCL.Model;
using UCL.UCL;

namespace UCL
{
    public class DbFunctions
    {
        static UCLContext ctx = new UCLContext();

        #region Functii pentru afisarea fiecarei tabele
        public static void ShowTeams()
        {
            var teams = ctx.Teams.ToList();

            if (teams.Any())
            {
                foreach (var team in teams)
                {
                    Console.WriteLine(team.Name + ", " + team.Country);
                }
            }
            else
            {
                Console.WriteLine("Nu exista echipe!");
            }
        }

        public static void ShowPlayers()
        {
            var players = ctx.Players.ToList();

            if (players.Any())
            {
                foreach (var item in players)
                {
                    Console.WriteLine($"{item.FullName}, Salariu: {item.Salary}, Pozitie: {item.Position.Name}");
                }
            }
            else
            {
                Console.WriteLine("Nu exista jucatori!");
            }

        }

        public static void ShowMatches()
        {
            var matches = ctx.Matches.ToList();

            if (matches.Any())
            {
                foreach (var item in matches)
                {
                    string host = " - ";
                    string guest = " - ";
                    if (item.Host != null)
                        host = item.Host.Name;

                    if (item.Guest != null)
                        guest = item.Guest.Name;


                    Console.WriteLine($"MatchId: {item.Id}, {host} vs {guest}, Scor: {item.Score}");
                }
            }
            else
            {
                Console.WriteLine("Nu exista meciuri!");
            }
        }

        public static void ShowStadiums()
        {
            var stadiums = ctx.Stadiums.ToList();

            if (stadiums.Any())
            {
                foreach (var item in stadiums)
                {
                    Console.WriteLine($"Nume: {item.Name}, Capacity: {item.Capacity}");
                }
            }
            else
            {
                Console.WriteLine("Nu exista stadioane!");
            }

        }

        public static void ShowCoaches()
        {
            var coaches = ctx.Coaches.ToList();

            if (coaches.Any())
            {
                foreach (var item in coaches)
                {
                    string team = " - ";
                    if (item.Team != null)
                        team = item.Team.Name;

                    Console.WriteLine($"Nume: {item.FullName}, Echipa: {team}");
                }
            }
            else
            {
                Console.WriteLine("Nu exista antrenori!");
            }
        }

        public static void ShowMatchesPlayers()
        {
            var matchesPlayers = ctx.MatchesPlayers.ToList();
            if (matchesPlayers != null)
            {
                foreach (var item in matchesPlayers)
                {
                    Console.WriteLine($"Id: {item.Id}, Player: {item.Player.FullName}, MatchId: {item.MatchId},Rating: {item.Rating}, Goals: {item.Goals}");
                }
            }
            else
            {
                Console.WriteLine("Nu exista legaturi intre tabela Match si tabela Player");
            }
        }
        #endregion


        #region Functii folosite in implementarea cerintelor de mai jos
        public static Team FindTeamById(long id)
        {
            return ctx.Teams.FirstOrDefault(x => x.Id == id);
        }

        public static Player FindPlayerById(long id)
        {
            return ctx.Players.FirstOrDefault(x => x.Id == id);
        }

        public static Match FindMatchById(long id)
        {
            return ctx.Matches.FirstOrDefault(x => x.Id == id);
        }

        public static Match FindMatchByTeams(long hostId, long guestId)
        {
            return ctx.Matches.FirstOrDefault(x => x.HostId == hostId && x.GuestId == guestId);
        }

        public static Team DecideOverallWinner(Match tur, Match retur)
        {
            //daca meciul s-a terminat cu penalty, scorul e cel de la penalty si nu are cum sa fie remiza
            if (retur.EndsWithPenalty == true)
            {
                return retur.Winner;
            }
            else
            {
                //in cazul asta, host-ul e cel din primul meci
                var overallHostScore = tur.HostScore + retur.GuestScore;
                var overallGuestScore = tur.GuestScore + retur.HostScore;
                var diff = overallHostScore - overallGuestScore;

                //daca e remiza, trebuie sa se tina cont de cine a luat mai multe goluri acasa
                //daca e remiza si scorul e identic in ambele parti atunci in retur se joaca la penalty si iese un castigator (caz tratat mai sus inainte de apelarea functiei)
                //daca e remiza si scorul nu e identic, pierde echipa care a luat mai multe goluri acasa 
                //(sau, in alte cuvinte, pierde echipa care a fost gazda in meciul cu mai multe goluri)
                if (diff == 0)
                {
                    if (tur.HostScore + tur.GuestScore > retur.HostScore + retur.GuestScore)
                        return retur.Host;
                    else
                        return tur.Host;
                }
                else
                {
                    return diff > 0 ? tur.Host : tur.Guest;
                }
            }

        }
        #endregion


        #region READ/SELECT
        /// <summary>
        /// Afiseaza toti jucatorii si echipele la care joaca acestia
        /// </summary>
        public static void ShowPlayersWithTeam()
        {
            var players = ctx.Players.ToList();

            Console.WriteLine("Lista tuturor jucatorilor si echipele la care joaca acestia:");
            Console.WriteLine("Jucator ------------ Echipa");
            foreach (var item in players)
            {
                string team = "fara echipa";
                if (item.Team != null)
                    team = item.Team.Name;

                Console.WriteLine($"{item.FullName} - {team}");
            }
        }

        /// <summary>
        /// Afiseaza jucatorii care au avut rating-ul peste 90 intr-un meci, pozitia acestora in teren si 
        /// informatii despre meciul in care au facut acel rating, se afiseaza in ordinea desc a rating-ului
        /// </summary>
        public static void PlayersWhoHaveRatingOver90()
        {
            var players = ctx.MatchesPlayers.Where(x => x.Rating >= 90).OrderByDescending(x => x.Rating).ToList();

            if (players.Any())
            {
                Console.WriteLine("Jucatorii care au avut avut ratingul de la 90 in sus sunt:\n");
                foreach (var item in players)
                {
                    string echipa = " - ";
                    string host = " - ";
                    string guest = " - ";
                    if (item.Player.Team != null)
                        echipa = item.Player.Team.Name;

                    if (item.Match.Host != null)
                        host = item.Match.Host.Name;

                    if (item.Match.Guest != null)
                        guest = item.Match.Guest.Name;

                    Console.WriteLine($"{item.Player.FullName}, Rating: {item.Rating}, Position: {item.Player.Position.Name}, " +
                                        $"Echipa: {echipa}\nMeci: {host} vs {guest}, " +
                                        $"Rezultat: {item.Match.HostScore}:{item.Match.GuestScore}\n");
                }
            }
            else
            {
                Console.WriteLine("Nu s-au gasit jucatori cu rating >= 90!");
            }

        }


        /// <summary>
        /// Afiseaza jucatorii care au cele mai multe goluri inscrise (in ordinea descrescatoare a golurilor 
        /// (se afiseaza jucatorii care au cel putin un gol inscris)
        /// </summary>
        public static void PlayersWhoScoredMostGoals()
        {
            var players = ctx.MatchesPlayers.GroupBy(x => x.Player.FirstName + " " + x.Player.LastName).Select(y => new
            {
                PlayerName = y.Key,
                Goals = y.Sum(t => t.Goals)
            }).Where(x => x.Goals != 0).OrderByDescending(x => x.Goals).ToList();

            if (players.Any())
            {
                Console.WriteLine("Jucatorii care au inscris cele mai multe goluri sunt: ");
                foreach (var item in players)
                {
                    Console.WriteLine($"{item.PlayerName}: {item.Goals}");
                }
            }
            else
            {
                Console.WriteLine("Nu s-au gasit jucatori cu cel putin un gol inscris!");
            }
        }



        /// <summary>
        /// Afiseaza stadioanele pe care s-au jucat cele mai multe meciuri (in ordinea descrescatoare a meciurilor jucate)
        /// (se afiseaza doar stadioanele pe care s-a jucat cel putin un meci)
        /// </summary>
        public static void StadiumsWithMostMatches()
        {
            var stadiums = ctx.Matches.GroupBy(x => x.Host.Stadium.FirstOrDefault().Name).Select(y => new
            {
                StadiumName = y.Key,
                Matches = y.Count()
            }).Where(x => x.Matches != 0).OrderByDescending(x => x.Matches).ToList();

            if (stadiums.Any())
            {
                Console.WriteLine("Stadioanele pe care s-au jucat cele mai multe meciuri sunt: ");
                foreach (var item in stadiums)
                {
                    Console.WriteLine($"{item.StadiumName}: {item.Matches}");
                }
            }
            else
            {
                Console.WriteLine("Nu s-au gasit stadioane pe care s-a jucat cel putin un meci!");
            }

        }
        #endregion

        #region INSERT/UPDATE
        /// <summary>
        /// Adauga o echipa cu numele, tara si anul de infiintare date ca parametri.
        /// </summary>
        public static void AddTeam(string name, string country, int formationYear)
        {
            var newTeam = new Team
            {
                Name = name,
                Country = country,
                FormationYear = formationYear,
                Eliminated = false,
            };

            ctx.Teams.Add(newTeam);
            ctx.SaveChanges();
        }
        /// <summary>
        /// Adauga o echipa noua, cu numele, tara, anul de infiintare, stadionul, antrenorul si jucatorii specificati.
        /// </summary>
        public static void AddTeam(string name, string country, int formationYear, ICollection<Stadium> stadium,
                                   ICollection<Coach> coaches, ICollection<Player> players)
        {
            var newTeam = new Team
            {
                Name = name,
                Country = country,
                FormationYear = formationYear,
                Eliminated = false,
                Stadium = stadium,
                Coaches = coaches,
                Players = players
            };

            ctx.Teams.Add(newTeam);
            ctx.SaveChanges();
            Console.WriteLine($"Echipa {newTeam.Name} a fost adaugata cu success!");
        }



        /// <summary>
        /// Adauga un meci nou. Dupa ce se adauga meciul afiseaza castigatorul meciului (daca nu e remiza) si in cazul
        /// in care e retur, se elimina echipa care a pierdut dubla.
        /// (Functia cuprinde si add si update)
        /// </summary>
        public static void AddMatch(DateTime date, int hostScore, int guestScore, int type, bool endsWithPenalty,
                                       long hostId, long guestId)
        {
            var match = new Match
            {
                Date = date,
                HostScore = hostScore,
                GuestScore = guestScore,
                Type = type,
                EndsWithPenalty = endsWithPenalty,
                HostId = hostId,
                GuestId = guestId
            };

            if (FindTeamById(hostId) == null || FindTeamById(guestId) == null)
            {
                Console.WriteLine("Una dintre echipele introduse nu exista!");
                return;
            }

            if (FindTeamById(hostId).Eliminated == true || FindTeamById(guestId).Eliminated == true)
            {
                Console.WriteLine("Una dintre echipele introduse este deja eliminata!");
                return;
            }

            if (match.EndsWithPenalty == true && match.GuestScore == match.HostScore)
            {
                Console.WriteLine("Daca meciul se termina la penalty, scorul nu poate fi egal!");
                return;
            }

            //daca meciul e retur
            if (type == 2)
            {
                //gaseste meciul tur
                var tur = FindMatchByTeams(guestId, hostId);
                if (tur == null)
                {
                    Console.WriteLine("Nu s-a gasit meciul tur care corespunde acestui meci!");
                    return;
                }

                ctx.Matches.Add(match);

                Console.WriteLine($"---{match.Host.Name} vs {match.Guest.Name}-----");
                Console.WriteLine($"----------Scor {match.HostScore} - {match.GuestScore}-------------");

                var winner = DecideOverallWinner(tur, match);

                //eliminam echipa care a pierdut
                Team teamToEliminate = null;
                if (match.Host.Id == winner.Id)
                {
                    teamToEliminate = match.Guest;
                }
                else
                {
                    teamToEliminate = match.Host;
                }
                teamToEliminate.Eliminated = true;

                ctx.Teams.AddOrUpdate(teamToEliminate);
                ctx.SaveChanges();

                Console.WriteLine($"Meciul introdus fost retur, {winner.Name} merge mai departe!");
                Console.WriteLine($"Meciul tur s-a jucat pe {tur.Date.ToShortDateString()}, rezultat: {tur.Host.Name} {tur.HostScore} - {tur.GuestScore} {tur.Guest.Name}");

            }
            else
            {
                if (ctx.Matches.FirstOrDefault(x => x.HostId == match.HostId && x.GuestId == match.GuestId) != null)
                {
                    Console.WriteLine("Mai exista un meci tur intre cele doua echipe!");
                    return;
                }

                ctx.Matches.Add(match);
                ctx.SaveChanges();

                Console.WriteLine($"---{match.Host.Name} vs {match.Guest.Name}-----");
                Console.WriteLine($"----------Scor {match.HostScore} - {match.GuestScore}-------------");

                if (match.Winner != null)
                    Console.WriteLine($"Meciul a fost tur, {match.Winner.Name} a castigat!");
                else
                    Console.WriteLine("Meciul s-a terminat la egalitate!");
            }
        }



        /// <summary>
        /// Adauga o inregistrare in MatchPlayer in care sa se introduca statisticile unui jucator intr-un anumit meci,
        ///daca ratingul este sub 50 jucatorului i se va reduce 1% din salariu
        ///daca ratingul este peste 95, i se mareste salariul cu 1%
        /// </summary>
        public static void AddMatchPlayer(int minutesPlayer, int rating, int goals, int redCards, int yellowCards,
                                          long playerId, long matchId)
        {
            var matchPlayer = new MatchPlayer
            {
                MinutesPlayed = minutesPlayer,
                Rating = rating,
                Goals = goals,
                RedCards = redCards,
                YellowCards = yellowCards,
                PlayerId = playerId,
                MatchId = matchId
            };

            if (FindPlayerById(playerId) == null)
            {
                Console.WriteLine($"Jucatorul cu id-ul {playerId} nu a fost gasit!");
                return;
            }

            if (FindMatchById(matchId) == null)
            {
                Console.WriteLine($"Meciul cu id-ul {matchId} nu a fost gasit!");
                return;
            }

            //daca jucatorul si meciul exista, adaugam inregistrarea
            try
            {
                ctx.MatchesPlayers.Add(matchPlayer);
                ctx.SaveChanges();
                Console.WriteLine($"Legatura dintre jucatorul {matchPlayer.Player.FullName} si meciul " +
                                $"{matchPlayer.Match.Host.Name} vs {matchPlayer.Match.Guest.Name} a fost adaugata!");

                if (matchPlayer.Rating < 50 && matchPlayer.Player.Salary != null)
                {
                    Console.WriteLine($"Salariul jucatorului {matchPlayer.Player.FullName} a scazut cu {matchPlayer.Player.Salary / 100}");
                    matchPlayer.Player.Salary -= matchPlayer.Player.Salary / 100;
                    ctx.MatchesPlayers.AddOrUpdate(matchPlayer);
                }
                else if (matchPlayer.Rating > 95 && matchPlayer.Player.Salary != null)
                {
                    Console.WriteLine($"Bonus!! Salariul jucatorului {matchPlayer.Player.FullName} a crescut cu {matchPlayer.Player.Salary / 100}");
                    matchPlayer.Player.Salary += matchPlayer.Player.Salary / 100;
                    ctx.MatchesPlayers.AddOrUpdate(matchPlayer);
                }
                ctx.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                //arunca exceptia daca se incalca conditia indexului compus unic pus pe playerId si matchId
                Console.WriteLine("Exista o inregistrare duplicata cu acelasi playerId si matchId!");
            }
        }

        #endregion

        #region DELETE
        /// <summary>
        /// Sterge toate echipele care au fost eliminate
        /// </summary>

        public static void DeleteEliminatedTeams()
        {
            var teamsToDelete = ctx.Teams.Where(x => x.Eliminated == true).ToList();
            if (teamsToDelete.Any())
            {
                Console.WriteLine("S-au sters echipele: ");
                foreach (var item in teamsToDelete)
                {
                    //cascade delete este dezactivat
                    //am ales sa nu sterg toate entitatile legate de echipa care urmeaza sa fie stearsa si am pus null la FK-urile asociate
                    //doar stadionul l-am scos
                    foreach (var player in item.Players)
                    {
                        player.TeamId = null;
                    }
                    foreach (var coach in item.Coaches)
                    {
                        coach.TeamId = null;
                    }

                    var stadium = ctx.Stadiums.Where(x => x.TeamId == item.Id).FirstOrDefault();
                    ctx.Stadiums.Remove(stadium);

                    foreach (var matchAtHome in item.MatchesPlayedAtHome)
                    {
                        matchAtHome.Host = null;
                    }
                    foreach (var matchAway in item.MatchesPlayedAway)
                    {
                        matchAway.Guest = null;
                    }
                    Console.WriteLine(item.Name);

                    ctx.Teams.Remove(item);
                    ctx.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Nu exista echipe eliminate!");
            }
        }
        #endregion



        #region STORED PROCEDURE
        //am creat o clasa noua pentru procedura pt ca returna Player si era diferenta intre Id (codul meu) 
        //si PlayerId (returnat de la baza de date) => dadea eroare
        private class PlayerModel
        {
            public virtual string PlayerId { get; set; }
            public virtual string FirstName { get; set; }
            public virtual string LastName { get; set; }
        }

        /// <summary>
        /// Transfera un jucator la o noua echipa, actualizand salariul, anul de debut la echipa, si id-ul capitanului
        /// </summary>
        public static void ExecuteTransferProcedure(long PlayerToTransferId, long TeamId)
        {
            if(ctx.Players.FirstOrDefault(x => x.Id == PlayerToTransferId) == null)
            {
                Console.WriteLine("Jucatorul introdus nu exista!");
                return;
            }

            if(ctx.Teams.FirstOrDefault(x => x.Id == TeamId) == null)
            {
                Console.WriteLine("Echipa introdusa nu exista!");
                return;
            }

            var playerToTransferId = new SqlParameter("@playerToTransferId", PlayerToTransferId);
            var teamId = new SqlParameter("@teamId", TeamId);

            var transfer = ctx.Database.SqlQuery<PlayerModel>("exec UCL.TransferPlayer @playerToTransferId, @teamId", playerToTransferId, teamId).ToList();

            Console.WriteLine("Procedura executata cu succes !");

            var playerTransfered = ctx.Players.FirstOrDefault(x => x.Id == PlayerToTransferId);
            Console.WriteLine($"Jucatorul {playerTransfered.FullName} a fost transferat!");

        }
        #endregion
    }

}
