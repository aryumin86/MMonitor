using MMonitorLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Publication (Article in Mass Media, Post in Social Media, Comment to post/article/comment).
    /// </summary>
    public abstract class AbstractPublication
    {
        public long Id { get; set; }

        /// <summary>
        /// Publication address.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Shortened URL of publication (for search in DB and so on)
        /// </summary>
        public string UrlShorted { get; set; }

        /// <summary>
        /// Publication Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Publication content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Publicationwas published at.
        /// </summary>
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Source of publication.
        /// </summary>
        public TheSource Source { get; set; }
        public int SourceId { get; set; }

        /// <summary>
        /// Url MD5 hash.
        /// </summary>
        public string UrlHash { get; set; }

        /// <summary>
        /// Title MD5 hash.
        /// </summary>
        public string TitleHash { get; set; }

        /// <summary>
        /// Content MD5 hash.
        /// </summary>
        public string ContentHash { get; set; }

        /// <summary>
        /// If this publication is plagiat - this is a main publication.
        /// </summary>
        public AbstractPublication MainArticle { get; set; }

        /// <summary>
        /// Article data was taken from RSS only.
        /// </summary>
        public bool FromRSS { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public ICollection<TheComment> TheComments { get; set; }

        /// <summary>
        /// Cluster of publication.
        /// </summary>
        public Cluster Cluster { get; set; }
        public int? ClusterId { get; set; }
    }
}
