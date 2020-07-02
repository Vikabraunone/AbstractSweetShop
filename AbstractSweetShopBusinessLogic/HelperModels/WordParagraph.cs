using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.HelperModels
{
    /// <summary>
    /// Информация по каждому абзацу
    /// </summary>
    class WordParagraph
    {
        public List<string> Texts { get; set; }

        public WordParagraphProperties TextProperties { get; set; }

        public bool ParagraphIsCell { get; set; }
    }
}