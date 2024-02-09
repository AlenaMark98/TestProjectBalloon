using System.Collections;
using System.Collections.Generic;

namespace BalloonProject
{
    /// <summary>
    /// Интерфейс сохранения
    /// </summary>
    /// <typeparam name="T">тип объекта</typeparam>
    public interface ISaver<T>
    {
        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="_value">тип объекта</param>
        public void Save(T _value);
        /// <summary>
        /// Загрузка
        /// </summary>
        public void Load();
        /// <summary>
        /// Удаление
        /// </summary>
        public void Removed();
    }
}
