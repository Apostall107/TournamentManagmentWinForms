using AppLibrary.Connections.TextConnectionHandler;
using AppLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AppLibrary.Connections
{
    class TextConnector : IDataConnection
    {

        #region Filespath strings


        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModel.csv";
        private const string MatchupFile = "MatchupModel.csv";
        private const string MatchupEntryFile = "MatchupEntryModel.csv";

        public void CompleteTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile
                .FullTxtFilePath()
                .LoadFile()
                .ConvertToTournamentModels();

            tournaments.Remove(model);

            tournaments.SaveToTournamentFile();



            TournamentLogic.UpdateTournamentResults(model);
        }

        #endregion




        #region TextData Creation
        public void CreatePerson(PersonModel model)
        {
            int currentID = 1;

            List<Models.PersonModel> person = PeopleFile.FullTxtFilePath().LoadFile().ConvertToPersonModels();//load file and convert it to List

            if (person.Count > 0)
            {
                currentID = person.OrderByDescending(x => x.ID).First().ID + 1;  // incrementation of ID
            }

            model.ID = currentID;


            person.Add(model);//add new recorn with incremented ID

            person.SaveToPeopleFile(PeopleFile);

        }

        public void CreatePrize(Models.PrizeModel model)
        {

            int currentID = 1;


            List<Models.PrizeModel> prizes = PrizesFile.FullTxtFilePath().LoadFile().ConvertToPrizeModels();//load file and convert it to List

            if (prizes.Count > 0)
            {
                currentID = prizes.OrderByDescending(x => x.ID).First().ID + 1;  // incrementation of ID
            }

            model.ID = currentID;


            prizes.Add(model);//add new recorn with incremented ID

            prizes.SaveToPrizeFile(PrizesFile);

        }

        public void CreateTeam(TeamModel model)
        {
            //TODO: need to handle ID 1 team creating only.

            List<Models.TeamModel> teams = TeamFile.FullTxtFilePath().LoadFile().ConvertToTeamModels();//load file and convert it to List

            int currentID = 1;


            if (teams.Count > 0)
            {
                currentID = teams.OrderByDescending(x => x.ID).First().ID + 1;  // incrementation of ID
            }

            model.ID = currentID;


            teams.Add(model);//add new recorn with incremented ID

            teams.SaveToTeamFile(TeamFile);

        }

        public void CreateTournament(TournamentModel model)
        {
            List<Models.TournamentModel> tournaments = TournamentFile.FullTxtFilePath().LoadFile().ConvertToTournamentModels();

            int currentID = 1;


            if (tournaments.Count > 0)
            {
                currentID = tournaments.OrderByDescending(x => x.ID).First().ID + 1;  // incrementation of ID
            }

            model.ID = currentID;


            model.SoveRoundsToFile();

            tournaments.Add(model);//add new recorn with incremented ID

            tournaments.SaveToTournametFile(TournamentFile);


        }



        #endregion


        public List<PersonModel> People_GetAll()
        {
            return PeopleFile.FullTxtFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> Teams_GetAll()
        {
            return TeamFile.FullTxtFilePath().LoadFile().ConvertToTeamModels();
        }

        public List<TournamentModel> Tournament_GetAll()
        {
            return GlobalConfig.TournamentFile.FullTxtFilePath().LoadFile().ConvertToTournamentModels();
        }

        public void UpdateMatchup(MatchupModel model)
        {

            model.UpdateMatchupToFile();

        }
    }
}