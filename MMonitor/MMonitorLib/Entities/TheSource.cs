using MMonitorLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Источник контента. (СМИ, СМ).
    /// </summary>
    public class TheSource
    {
        public int Id { get; set; }

        /// <summary>
        /// Название источника.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание источника.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип источника.
        /// </summary>
        public TheSourceType TheSourceType { get; set; } 

        /// <summary>
        /// Кодировка источника.
        /// </summary>
        public string Enc { get; set; }

        /// <summary>
        /// Язык источника.
        /// </summary>
        public Langs Lang { get; set; }

        /// <summary>
        /// Правила парсинга источника.
        /// </summary>
        public IEnumerable<PageParsingRule> Rules;

        /// <summary>
        /// Один для всех правил источника UserAgent. 
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Таймаут при обращении к источнику.
        /// </summary>
        public int RequestTimeOut { get; set; }
    }
}
