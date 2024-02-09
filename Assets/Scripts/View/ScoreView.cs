using UnityEngine;
using UnityEngine.UI;

namespace BalloonProject.View
{
    /// <summary>
    /// Вьюшка для счетчика
    /// </summary>
    public class ScoreView : MonoBehaviour
    {   
        private Text _score = default;

        private int _currentScore = 0;

        /// <summary>
        /// Текущий счет
        /// </summary>
        public int CurrentScore 
        {
            get => _currentScore;
            set
            {
                if (value != _currentScore)
                {
                    _currentScore = value;
                }
            }
        }

        private void Awake() => _score = GetComponent<Text>();

        private void Update() => _score.text = _currentScore.ToString();
    }
}
