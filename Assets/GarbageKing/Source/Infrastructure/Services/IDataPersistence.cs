using PixupGames.Persitence.Models;

namespace PixupGames.Infrastracture.Services
{
    public interface IDataPersistence
    {
        Data Data { get; set; }

        void Save();
    }
}