using UnityEngine;
using BalloonProject.View;

namespace BalloonProject
{
    /// <summary>
    /// Менеджер счетчик
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private ScoreView _ScoreView;

        public int CurrentScore = 0;

        /// <summary>
        /// Обновить счет
        /// </summary>
        /// <param name="_number"></param>
        public void UpdateScore(int _number = 0)
        {
            _ScoreView.CurrentScore += _number;
            CurrentScore = _ScoreView.CurrentScore;
        }
    }
}
