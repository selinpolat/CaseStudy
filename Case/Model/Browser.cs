﻿using Case.Model;
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
        public SearchPage SearchPage { get; private set; }
        public SearchEngine SearchEngine { get; private set; }
        public string SearchURL { get; private set; }

        public Dictionary<SearchEngine, string> searchEngineURLs = new Dictionary<SearchEngine, string>()
        {
            {SearchEngine.Chrome,"https://www.google.com.tr/search" },
            {SearchEngine.Yandex,"https://yandex.com.tr/search" },
        };
        public Browser(SearchEngine searchEngine)
        {
            SearchEngine = searchEngine;
            SearchURL = searchEngineURLs[searchEngine];
        }      
    }
}
