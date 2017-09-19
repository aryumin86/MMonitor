using MMonitorLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Абстрактный класс публикации (поста, статьи в сми).
    /// </summary>
    public abstract class AbstractPublication
    {
        /// <summary>
        /// Id публикации
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Адрес публикации.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Заголовок публикации.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Содержание публикации.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата и время публикации.
        /// </summary>
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Источник публикации.
        /// </summary>
        public TheSource Source { get; set; }

        /// <summary>
        /// Хеш урла.
        /// </summary>
        public string UrlHash { get; set; }

        /// <summary>
        /// Хеш заголовка.
        /// </summary>
        public string TitleHash { get; set; }

        /// <summary>
        /// Хеш контента.
        /// </summary>
        public string ContentHash { get; set; }

        /// <summary>
        /// Список публикаций плагиатов - очень похожих или полных копий.
        /// </summary>
        public List<AbstractPublication> Plagiats;

        /// <summary>
        /// Язык публикации.
        /// </summary>
        public Langs Lang { get; set; }
    }
}
