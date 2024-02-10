using UnityEngine;
using System;

namespace BalloonProject
{
    /// <summary>
    /// Менеджер счетчик
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        /// <summary>
        /// Время окончено 
        /// </summary>
        public event Action<int> OnUpdateScore = delegate { };

        private int _currentScore = 0;

        /// <summary>
        /// Обновить счет
        /// </summary>
        /// <param name="_number"></param>
        public void UpdateScore(int _number = 0)
        {
            _currentScore += _number;
            OnUpdateScore(_currentScore);
        }
    }
}
