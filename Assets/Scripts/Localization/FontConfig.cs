using System;
using System.Collections.Generic;
namespace Menchestan
{
    namespace Localization
    {
        public class LangFontDesign
        {
            public Dictionary<Language, LangFont> langFontPacks = new Dictionary<Language, LangFont>();
            public Action<LangFont> OnLanguageChanged;
        }
    }
}