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
                    string MagazineID = row["ID"].ToString();
                    string[] temp = { MagazineID };
                    DataTable dtMagazineIssues = base.Select(MagazineIssueService.ViewMagazineIssues, temp);

                    List<MagazineIssueDTO> MagazineIssues = new List<MagazineIssueDTO>();
                    foreach (DataRow magazineIssueRow in dtMagazineIssues.Rows)
                    {
                        bool AvailableToNonSubscribers = false;
                        if (magazineIssueRow["AvailableToNonSubscribers"].ToString() == "1")
                            AvailableToNonSubscribers = true;


                        MagazineIssues.Add(new MagazineIssueDTO()
                        {
                            // Insert ID ??
                            IssueNumber = int.Parse(magazineIssueRow["IssueNumber"].ToString()),
                            DateTimeReleased = DateTime.Parse(magazineIssueRow["DateTimeReleased"].ToString()),
                            CostToDownload = float.Parse(magazineIssueRow["CostToDownload"].ToString()),
                            AvailableToNonSubscribers = AvailableToNonSubscribers,
                            IssueFileName = magazineIssueRow["IssueFileName"].ToString(),
                            IssueThumbnailName = magazineIssueRow["IssueThumbnailName"].ToString()
                        });
                    }

                    Magazines.Add(new MagazineDTO()
                    {
                        MagazineID = MagazineID,
                        Name = row["MagazineName"].ToString(),
                        SubscriptionCost = double.Parse(row["SubscriptionCost"].ToString()),
                        MagazineIssues = MagazineIssues
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
