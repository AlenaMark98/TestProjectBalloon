using System;
using System.Collections.Generic;

namespace BalloonProject.Data
{
    /// <summary>
    /// Данные результата
    /// </summary>
    [Serializable]
    public class Result
    {
        /// <summary>
        /// ID результата
        /// </summary>
        public string ID;
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name;
        /// <summary>
        /// Время обратного отчета
        /// </summary>
        public float Time;
        /// <summary>
        /// дата получения результата
        /// </summary>
        public string Date;
        /// <summary>
        /// Полученные очки
        /// </summary>
        public int Score;
    }

    /// <summary>
    /// Результатты
    /// </summary>
    [Serializable]
    public class Results
    {
        /// <summary>
        /// Список всех результатов
        /// </summary>
        public List<Result> ListAllResults = new List<Result>();
    }
}
