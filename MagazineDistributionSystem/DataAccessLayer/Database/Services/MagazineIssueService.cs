using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database.Services.Base;
using DataAccessLayer.Database.Enums;

namespace DataAccessLayer.Database.Services
{
    public class MagazineIssueService : BaseService, IDisposable
    {
        #region Fields

        private const DatabaseViews View = DatabaseViews.AllMagazines;
        internal const DatabaseViews ViewMagazineIssues = DatabaseViews.MagazineIssuesForAMagazine;
        private const DatabaseInsertableTables InsertProc = DatabaseInsertableTables.Magazine;
        private const DatabaseUpdateableTables UpdateProc = DatabaseUpdateableTables.Magazine;
        private const DatabaseDeleteableTables DeleteProc = DatabaseDeleteableTables.Magazine;

        #endregion

        #region Constructors

        public MagazineIssueService()
        {

        }

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #region Interface implementation

        #region IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #endregion
    }
}
