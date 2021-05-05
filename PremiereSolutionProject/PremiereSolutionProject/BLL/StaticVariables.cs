using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.BLL
{
    public class StaticVariables
    {
        #region Fields
        private double platinumPrice;   //refers to price per day
        private double goldPrice;
        private double silverPrice;
        private double bronzePrice;

        private int platinumDays;       //refers to max nr of days to respond (max range)
        private int goldDays;
        private int silverDays;
        private int bronzeDays;
        #endregion

        #region Properties
        public double PlatinumPrice { get => platinumPrice; set => platinumPrice = 10000.00; }
        public double GoldPrice { get => goldPrice; set => goldPrice = 8000.00; }
        public double SilverPrice { get => silverPrice; set => silverPrice = 6500.00; }
        public double BronzePrice { get => bronzePrice; set => bronzePrice = 4000.00; }
        public int PlatinumDays { get => platinumDays; set => platinumDays = 2; }
        public int GoldDays { get => goldDays; set => goldDays = 4; }
        public int SilverDays { get => silverDays; set => silverDays = 6; }
        public int BronzeDays { get => bronzeDays; set => bronzeDays = 8; }
        #endregion
    }
}
