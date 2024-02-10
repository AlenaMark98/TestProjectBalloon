using UnityEngine;
using System.IO;

namespace BalloonProject
{
    /// <summary>
    /// Абстрактный класс сохранение
    /// </summary>
    public abstract class Saver : MonoBehaviour
    {
        [SerializeField] protected string savePath;
        [SerializeField] protected string saveFileName = "data.json";

        protected virtual void Awake()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
            savePath = Path.Combine(Application.streamingAssetsPath, saveFileName);
#endif
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        public abstract void Save();
        /// <summary>
        /// Загрузка
        /// </summary>
        public abstract void Load();
        /// <summary>
        /// Удаление
        /// </summary>
        public abstract void Removed();
    }
}
