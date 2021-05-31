
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.Connections.TextConnectionHandler;

namespace AppLibrary.Connections
{
    class TextConnector : IDataConnection
    {
        // TODO - realize method. Connect the CreateNewPrize for txt file.


        private const string PrizesFile = "PrizeModels.csv";


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

    }
}