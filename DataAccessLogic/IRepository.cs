using URL_Shortening.Models;

namespace URL_Shortening.DataAccessLogic
{
    public interface IRepository
    {
        ShortURL? Get(int Id);
        bool Create(ShortURL shortURL);
        void Update(ShortURL shortURL);
        void Delete(int id);

    }
}
