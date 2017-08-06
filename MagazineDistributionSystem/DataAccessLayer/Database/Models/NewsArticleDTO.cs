using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database.Models
{
    public class NewsArticleDTO
    {
        #region Fields

        #endregion

        #region Constructors

        public NewsArticleDTO()
        {

        }

        public NewsArticleDTO(string NewsArticleIDParam, string TitleParam, string ArticleTextParam, string AuthorParam, DateTime DateTimePublishedParam)
        {
            this.NewsArticleID = NewsArticleIDParam;
            this.Title = TitleParam;
            this.ArticleText = ArticleTextParam;
            this.Author = AuthorParam;
            this.DateTimePublished = DateTimePublishedParam;
        }

        #endregion

        #region Properties

        public string NewsArticleID { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public string Author { get; set; }
        public DateTime DateTimePublished { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
