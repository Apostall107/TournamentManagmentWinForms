using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Connections
{
    class TextConnector : IDataConnection
    {
        // TODO - realize method.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.ID = 1;

            return model;
        }

    }
}