using System.IO;
using UnityEngine;

namespace PixupGames.Infrastracture.Services
{
    public class GameSaves<T> : IGameSaves<T> where T: class
    {
        private readonly string _saveKey;
        private readonly T _defaultSaves;

        public GameSaves(T defaultSaves, string saveKey)
        {
            _defaultSaves = defaultSaves;
            _saveKey = saveKey;
        }

        public T Progress()
        {
            if (PlayerPrefs.HasKey(_saveKey))
            {
                var json = PlayerPrefs.GetString(_saveKey);
                return json.ToDeserialized<T>();
            }

            return _defaultSaves;
        }

        public void Save(T save) =>
            PlayerPrefs.SetString(_saveKey, save.ToJson());
    }
}
