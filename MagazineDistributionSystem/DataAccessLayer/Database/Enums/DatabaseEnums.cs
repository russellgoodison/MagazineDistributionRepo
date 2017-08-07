﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database.Enums
{
    internal enum DatabaseViews
    {
        ActiveSessions, AllAddresses, AllMagazineIssueDownloads, AllMagazines, AllSubscriptions, AllUsers, AllNewsArticles, MagazineIssuesForAMagazine
    }

    internal enum DatabaseInsertableTables
    {
        Address, Magazine, MagazineIssue, MagazineIssueDownload, Session, Subscription, User, NewsArticle
    }

    internal enum DatabaseUpdateableTables
    {
        Address, Magazine, MagazineIssue, Subscription, User, NewsArticle
    }

    internal enum DatabaseDeleteableTables
    {
        Address, Magazine, MagazineIssue, Session, Subscription, User, NewsArticle
    }
}
