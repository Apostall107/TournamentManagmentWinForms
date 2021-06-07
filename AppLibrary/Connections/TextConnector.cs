
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.Connections.TextConnectionHandler;
using AppLibrary.Models;
using Dapper;

namespace AppLibrary.Connections
{
    class TextConnector : IDataConnection
    {

        #region Filespath strings


        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string  TournamentFile = "TournamentModel.csv";
        private const string  MatchupFile = "MatchupModel.csv";
        private const string  MatchupEntryFile = "MatchupEntryModel.csv";

        #endregion




        #region TextData Creation
        public Models.PersonModel CreatePerson(Models.PersonModel model)
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

            return model;
        }

        public Models.PrizeModel CreatePrize(Models.PrizeModel model)
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

            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            //TODO: need to handle ID 1 team creating only.

            List<Models.TeamModel> teams = TeamFile.FullTxtFilePath().LoadFile().ConvertToTeamModels(PeopleFile);//load file and convert it to List

            int currentID = 1;


            if (teams.Count > 0)
            {
                currentID = teams.OrderByDescending(x => x.ID).First().ID + 1;  // incrementation of ID
            }

            model.ID = currentID;


            teams.Add(model);//add new recorn with incremented ID

            teams.SaveToTeamFile(TeamFile);

            return model;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<Models.TournamentModel> tournaments = GlobalConfig.TournamentFile.FullTxtFilePath().LoadFile()
                .ConvertToTournamentModels(TeamFile, PeopleFile,PrizesFile);

            int currentID = 1;


            if (tournaments.Count > 0)
            {
                currentID = tournaments.OrderByDescending(x => x.ID).First().ID + 1;  // incrementation of ID
            }

            model.ID = currentID;


            model.SoveRoundsToFile();

            tournaments.Add(model);//add new recorn with incremented ID

            tournaments.SaveToTournametFile(TournamentFile);

            return model;
        }



        #endregion


        public List<PersonModel> People_GetAll()
        {
            return PeopleFile.FullTxtFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> Teams_GetAll()
        {
            return TeamFile.FullTxtFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }
   
    



    }
}