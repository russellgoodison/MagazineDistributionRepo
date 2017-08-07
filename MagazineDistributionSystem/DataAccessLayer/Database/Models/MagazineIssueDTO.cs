using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database.Models
{
    public class MagazineIssueDTO
    {
        #region Fields

        #endregion

        #region Constructors

        public MagazineIssueDTO()
        {

        }

        public MagazineIssueDTO(string MagazineIssueIDParam, int IssueNumberParam, DateTime DateTimeReleasedParam, float CostToDownloadParam, bool AvailableToNonSubscribersParam, string IssueFileNameParam, string IssueThumbnailNameParam)
        {
            this.MagazineIssueID = MagazineIssueIDParam;
            this.IssueNumber = IssueNumberParam;
            this.DateTimeReleased = DateTimeReleasedParam;
            this.CostToDownload = CostToDownloadParam;
            this.AvailableToNonSubscribers = AvailableToNonSubscribersParam;
            this.IssueFileName = IssueFileNameParam;
            this.IssueThumbnailName = IssueThumbnailNameParam;
        }

        #endregion

        #region Properties

        public string MagazineIssueID { get; set; }
        public int IssueNumber { get; set; }
        public DateTime DateTimeReleased { get; set; }
        public float CostToDownload { get; set; }
        public bool AvailableToNonSubscribers { get; set; }
        public string IssueFileName { get; set; }
        public string IssueThumbnailName { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
