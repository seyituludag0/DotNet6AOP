using Business.Abstracts;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Business.Concretes
{
    public class NewsManager : INewsService
    {
        [ExceptionLogAspect(typeof(FileLogger))]
        public List<NewsItem> EuroBuildCEE()
        {
            //string RSSURL = "https://localhost:44363/api/News/PropertyNL";
            string RSSURL = "https://eurobuildcee.com/en/news/rsss";
            List<NewsItem> newsItems = new List<NewsItem>();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(RSSURL);

            XmlNode nodes = xmlDocument.SelectSingleNode("//channel");
            var linkText = nodes.SelectSingleNode("link");
            string sourceLink = linkText.InnerText;

            foreach (XmlNode node in nodes)
            {

                XmlNode publishDate = node.SelectSingleNode("pubDate");
                XmlNode title = node.SelectSingleNode("title");
                XmlNode description = node.SelectSingleNode("description");
                XmlNode link = node.SelectSingleNode("link");

                if (publishDate != null && title != null && description != null && link != null)
                {
                    NewsItem feed = new NewsItem();

                    feed.Title = title.InnerText;
                    feed.Description = description.InnerText;

                    newsItems.Add(feed);
                }
            }
            return newsItems;
        }
    }
}
