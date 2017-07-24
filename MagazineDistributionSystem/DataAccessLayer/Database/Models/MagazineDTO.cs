using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database.Models
{
    public class MagazineDTO
    {
        #region Fields

        #endregion

        #region Constructors

        public MagazineDTO()
        {

        }

        public MagazineDTO(string MagazineIDParam, string NameParam, double SubscriptionCostParam)
        {
            this.MagazineID = MagazineIDParam;
            this.Name = NameParam;
            this.SubscriptionCost = SubscriptionCostParam;
        }

        #endregion

        #region Properties

        public string MagazineID { get; set; }
        public string Name { get; set; }
        public double SubscriptionCost { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
