using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.Models;

namespace TournamentManagementWinForms
{
    public static class TournamentLogic
    {

        public static void CreateRounds(AppLibrary.Models.TournamentModel model)
        {

            List<AppLibrary.Models.TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int roundSkips = NumberOfRoundSkips(rounds, randomizedTeams.Count);



            model.Rounds.Add(CreateFirstRound(roundSkips, randomizedTeams));


            CreateOtherRounds(model, rounds);

            UpdateTournamentResults(model);


        }


        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel rm in round)
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            MarkWinnersInMatchups(toScore);

            AdvancedWinners(toScore, model);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

            int endingRound = model.CheckCurrentRound();

            if (endingRound > startingRound)
            {
                model.AlertUsersToNewRound();
            }
        }



        private static void CreateOtherRounds(AppLibrary.Models.TournamentModel model, int rounds)
        {

            int round = 2;
            List<AppLibrary.Models.MatchupModel> previousRound = model.Rounds[0];
            var currentRound = new List<AppLibrary.Models.MatchupModel>();
            var currentMatchup= new AppLibrary.Models.MatchupModel();

            while (round <= rounds)
            {
                foreach (var match in previousRound)
                {

                    currentMatchup.Entries.Add(new AppLibrary.Models.MatchupEntryModel { ParentMatchup = match } ) ;

                    if (currentMatchup.Entries.Count > 1)
                    {

                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new AppLibrary.Models.MatchupModel();

                    }
                    model.Rounds.Add(currentRound);
                    previousRound = currentRound;

                    currentRound = new List<AppLibrary.Models.MatchupModel>();
                    round++;

                }
            }
          

        
        }

        private static List<AppLibrary.Models.MatchupModel> CreateFirstRound(int roundSkips, List<AppLibrary.Models.TeamModel> teams)
        {

            //TODO take an eye;
            var output = new List<AppLibrary.Models.MatchupModel>();
            var curr = new AppLibrary.Models.MatchupModel();

            foreach (var team in teams)
            {
                curr.Entries.Add(new AppLibrary.Models.MatchupEntryModel { TeamCompeting = team });

                if (roundSkips > 0 || curr.Entries.Count > 1)
                {

                    curr.MatchupRound = 1;
                    output.Add(curr);

                    curr = new AppLibrary.Models.MatchupModel();

                    if (roundSkips > 0)
                    {

                        roundSkips--;

                    }

                }


                
            }


            return output;

        }

        private static int NumberOfRoundSkips(int rounds, int teamsQuantity)
        {

            int output = 0;
            int totalTeams = 0;

            for (int i = 1; i <= rounds; i++)
            {

                totalTeams *= 2;

            }

            output = totalTeams - teamsQuantity;

            return output;

        }

        private static int FindNumberOfRounds(int teamsQuantity)
        {

            int output = 1;
            int val = 2;

            while (val < teamsQuantity)
            {

                output++;

                val *= 2;

            }

            return output;

        }
        private static List<AppLibrary.Models.TeamModel> RandomizeTeamOrder(List<AppLibrary.Models.TeamModel> teams)
        {

            return teams.OrderBy(x => Guid.NewGuid()).ToList();

        }





    }
}
