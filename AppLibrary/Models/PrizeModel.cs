using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models
{
    public class PrizeModel
    {

        public int ID { get; set; }

        public int PlaceNumber { get; set; }

        /// <summary>
        /// Needed if there are not only num places , bit places as Champions etc.
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        ///  Prize amont given , based on your placement in the tournament.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        ///  alter PrizeAmount.
        ///  Prize amount based on persentage of tournament budget 
        /// </summary>
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
        {


            this.PlaceName = placeName;


            int _PlaceNumberValue = 0;
            int.TryParse(placeNumber, out _PlaceNumberValue);

            this.PlaceNumber = _PlaceNumberValue;


            decimal _PrizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out _PrizeAmountValue);

            this.PrizeAmount = _PrizeAmountValue;


            double _PrizePercentageValue = 0;
            double.TryParse(prizePercentage, out _PrizePercentageValue);

            this.PrizePercentage = _PrizePercentageValue;


        }


    }
}
