using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database.Enums;
using DataAccessLayer.Database.Services.Base;
using DataAccessLayer.Database.Models;
using System.Data;

namespace DataAccessLayer.Database.Services
{
    public class NewsArticleService : BaseService, IDisposable
    {
        #region Fields

        private const DatabaseViews View = DatabaseViews.AllNewsArticles;
        private const DatabaseInsertableTables InsertProc = DatabaseInsertableTables.NewsArticle;
        private const DatabaseUpdateableTables UpdateProc = DatabaseUpdateableTables.NewsArticle;
        private const DatabaseDeleteableTables DeleteProc = DatabaseDeleteableTables.NewsArticle;

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods

        public List<NewsArticleDTO> GetAll()
        {
            try
            {
                List<NewsArticleDTO> NewsArticles = new List<NewsArticleDTO>();
                DataTable dt = base.Select(View);
                foreach (DataRow row in dt.Rows)
                {
                    NewsArticles.Add(new NewsArticleDTO()
                    {
                        NewsArticleID = row["ID"].ToString(),
                        Title = row["Title"].ToString(),
                        ArticleText = row["ArticleText"].ToString(),
                        Author = row["Author"].ToString(),
                        DateTimePublished = DateTime.Parse(row["DateTimePublished"].ToString())
                    });
                }
                return NewsArticles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
