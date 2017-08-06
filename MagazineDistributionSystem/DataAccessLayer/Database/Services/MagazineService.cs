using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database.Services.Base;
using DataAccessLayer.Database.Enums;
using DataAccessLayer.Database.Models;
using System.Data;

namespace DataAccessLayer.Database.Services
{
    public class MagazineService : BaseService, IDisposable
    {
        #region Fields

        private const DatabaseViews View = DatabaseViews.AllMagazines;
        private const DatabaseInsertableTables InsertProc = DatabaseInsertableTables.Magazine;
        private const DatabaseUpdateableTables UpdateProc = DatabaseUpdateableTables.Magazine;
        private const DatabaseDeleteableTables DeleteProc = DatabaseDeleteableTables.Magazine;

        #endregion

        #region Constructors

        public MagazineService()
        {

        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region Get

        public List<MagazineDTO> GetAll()
        {
            try
            {
                List<MagazineDTO> Magazines = new List<MagazineDTO>();
                DataTable dt = base.Select(View);
                foreach (DataRow row in dt.Rows)
                {
                    Magazines.Add(new MagazineDTO()
                    {
                        MagazineID = row["ID"].ToString(),
                        Name = row["MagazineName"].ToString(),
                        SubscriptionCost = double.Parse(row["SubscriptionCost"].ToString())
                    });
                }
                return Magazines;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
