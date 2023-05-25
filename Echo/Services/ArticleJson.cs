using Echo.Interfaces;
using Echo.Models;
using Echo.Helpers;

namespace Echo.Services
{
    public class ArticleJson : IArticleRepository
    {
        const string JsonFileName = @"Data\Articles.json";

        public void AddArticle(Article article)
        {
            Dictionary<int, Article> articles = AllArticles();
            articles.Add(article.Id, article);
            JsonFileWriter.WriteArticleToJson(articles, JsonFileName);
        }
        public Dictionary<int, Article> AllArticles()
        {
            return JsonFileReader.ReadJsonArticle(JsonFileName);
        }

        public Article GetArticle(int id)
        {
            Dictionary<int, Article> articles = AllArticles();
            Article foundArticle;
            foreach (var a in articles.Values)
            {
                if (a.Id.Equals(id))
                {
                    foundArticle = a;
                    return foundArticle;
                }
            }
            return null;
        }
       
        public void UpdateArticle (Article article)
        {
            Dictionary<int, Article> articles = AllArticles();
            Article foundArticle = articles[article.Id];
            foundArticle.Id = article.Id;
            foundArticle.Name= article.Name;
            foundArticle.Header = article.Header;
            foundArticle.Subheader = article.Subheader;
            foundArticle.Bodytext = article.Bodytext;
            JsonFileWriter.WriteArticleToJson(articles, JsonFileName);
        }
        public bool ArticleExists(int id)
        {
            Dictionary<int, Article> articles = AllArticles();

            foreach (var e in articles.Values)
            {
                if (e.Id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteArticle(int id)
        {
            Dictionary<int, Article> articles = AllArticles();
            articles.Remove(id);
            JsonFileWriter.WriteArticleToJson(articles, JsonFileName);
        }

        

    }
}
