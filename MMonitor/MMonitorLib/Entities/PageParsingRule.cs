using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Правило парсинга страницы.
    /// </summary>
    public class PageParsingRule
    {
        public int Id { get; set; }

        /// <summary>
        /// Может ли быть несколько публикаций,
        /// удовлетворяющих этому правилу парсинга, на странице.
        /// </summary>
        public bool AllowMuliplyPublicationsOnPage { get; set; }

        /// <summary>
        /// Дата создания правила.
        /// </summary>
        public DateTime RuleCreationDate { get; set; }

        /// <summary>
        /// Регулярное выражение, которому должен соответствовать URL.
        /// </summary>
        public string UrlRegex { get; set; }

        /// <summary>
        /// Заголовок должен соответствовать этому регулярному выражению.
        /// </summary>
        public string TitleRegex { get; set; }

        /// <summary>
        /// Автор создания этого правила.
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Средняя оценка правила пользователями.
        /// </summary>
        public double AverageEvaluation { get; set; }

        /// <summary>
        /// Правило отклонено пользователем на клиентском приложении.
        /// </summary>
        public bool RejectedByUser { get; set; }
    }
}
