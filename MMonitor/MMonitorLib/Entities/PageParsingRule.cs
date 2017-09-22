using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Rule of page parsing.
    /// </summary>
    [Table("PageParsingRules")]
    public class PageParsingRule
    {
        public int Id { get; set; }

        /// <summary>
        /// XPATH rule for content of publication.
        /// </summary>
        public string ContentXPath { get; set; }

        /// <summary>
        /// XPATH rule for pub date of publication.
        /// </summary>
        public string PubDateXPath { get; set; }

        /// <summary>
        ///  XPATH rule for author of publication.
        /// </summary>
        public string AuthorXPath { get; set; }

        /// <summary>
        /// Rule creation date.
        /// </summary>
        public DateTime RuleCreationDate { get; set; }

        /// <summary>
        /// Regex for URL - only pages with urls match this regex are valid for this rule.
        /// </summary>
        public string UrlRegex { get; set; }        

        /// <summary>
        /// Regex for title - only pages with title match this regex are valid for this rule.
        /// </summary>
        public string TitleRegex { get; set; }

        /// <summary>
        /// User's Id who created this rule.
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// Average evaluation mark for this rule
        /// </summary>
        public double? AverageRuleEvaluation { get; set; }

        /// <summary>
        /// Rule was rejected by user in client app.
        /// </summary>
        public bool? RejectedByUser { get; set; }

        /// <summary>
        /// Regex for deliting parts of content of publication.
        /// </summary>
        public string EraseContentPartsRegex;

        /// <summary>
        /// Regex for deliting parts of title content of publication.
        /// </summary>
        public string EraseTitlePartsRegex;

        /// <summary>
        /// Regex for deliting parts of author content of publication.
        /// </summary>
        public string EraseAuthorPartsRegex;

        /// <summary>
        /// Regex for deliting parts of publication date content of publication.
        /// </summary>
        public string ErasePubDatePartsRegex;
    }
}
