using Echo.Models;

namespace Echo.Interfaces
{
    public interface IArticleRepository
    {
        Dictionary<int, Article> AllArticles();

        Article GetArticle(int id);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
        bool ArticleExists(int id);

        void DeleteArticle(int id);
    }
}
