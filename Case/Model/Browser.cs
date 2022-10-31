using Case.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.PageObject
{
    public class Browser
    {
        public SearchEngine SearchEngine { get; private set; }
        public string SearchURL { get; private set; }

        private readonly Dictionary<SearchEngine, string> searchEngineURLs = new Dictionary<SearchEngine, string>()
        {
            {SearchEngine.Google,"https://www.google.com.tr/search" },
            {SearchEngine.Yandex,"https://yandex.com.tr/search" },
        };

        public Browser(SearchEngine searchEngine)
        {
            SearchEngine = searchEngine;
            SearchURL = searchEngineURLs[searchEngine];
        }      
    }
}
