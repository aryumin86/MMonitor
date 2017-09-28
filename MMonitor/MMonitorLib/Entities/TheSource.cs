using MMonitorLib.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// The source (Mass media or Social media).
    /// </summary>
    [Table("TheSources")]
    public class TheSource
    {
        public int Id { get; set; }

        /// <summary>
        /// Source title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Main page of source.
        /// </summary>        
        public string Url { get; set; }

        /// <summary>
        /// Hash of url.
        /// </summary>
        [Index]
        [MaxLength(32)]
        public string UrlHash { get; set; }

        /// <summary>
        /// Source description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Source type.
        /// </summary>
        public TheSourceType TheSourceType { get; set; }

        /// <summary>
        /// Type of Media Audience.
        /// </summary>
        public MediaAudienceType MediaAudienceType { get; set; }

        /// <summary>
        /// Source encoding.
        /// </summary>
        public string Enc { get; set; }

        /// <summary>
        /// Source language.
        /// </summary>
        public Langs Lang { get; set; }

        /// <summary>
        /// Source parsing rules.
        /// </summary>
        public ICollection<PageParsingRule> PageParsingRules { get; set; }

        /// <summary>
        /// Source UserAgent. 
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Timeout of request to the source in ms.
        /// </summary>
        public int RequestTimeOut { get; set; }

        /// <summary>
        /// Source RSS pages.
        /// </summary>
        public ICollection<RssPage> RssPages { get; set; }

        /// <summary>
        /// Pages to parse for new publications.
        /// </summary>
        public ICollection<NewsPage> NewsPages { get; set; }

        /// <summary>
        /// Last time there was an attempt to update 
        /// the rules of the source AUTOMATICALLY.
        /// </summary>
        public DateTime? LastTimeAutomaticalRulesUpdateEffort { get; set; }

        /// <summary>
        /// Last time there was an attempt to identify encoding.
        /// </summary>
        public DateTime? LastTimeAutomaticalEncodingUpdateEffort { get; set; }

        /// <summary>
        /// Was last attempt of updating the rules success
        /// (if yes than true, no - false, null - were not attempts at all).
        /// </summary>
        public bool? AutomaticalRulesUpdateWasSuccess { get; set; }

        /// <summary>
        /// Was last attempt to identify encoding success.
        /// </summary>
        public bool? AutomaticalEncodingUpdateWasSuccess { get; set; }

        /// <summary>
        /// The offered new source is approved or not.
        /// </summary>
        public bool? IsApproved { get; set; }

        /// <summary>
        /// Country of Media.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// How many publications are posted per day in this source.
        /// </summary>
        public double AverageNumOfPublicationsPerDay { get; set; }
    }
}
