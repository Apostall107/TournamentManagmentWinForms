
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
            throw new NotImplementedException();
        }



        #endregion


        public List<PersonModel> People_GetAll()
        {
            return PeopleFile.FullTxtFilePath().LoadFile().ConvertToPersonModels();
        }




    }
}