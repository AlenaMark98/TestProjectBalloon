using BalloonProject.View;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BalloonProject
{
    /// <summary>
    /// Менеджер вьюшек
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameOverView _gameOver = default;
        [SerializeField] private TimeView _timeView = default;
        [SerializeField] private ScoreView _scoreView = default;

        private TimerManager _timeManager = default;
        private ScoreManager _scoreManager = default;
        private ResultsSaver _resultSaver = default;

        private void Start()
        {
            _timeManager = Bootstrap.Instance.TimerManager;
            _scoreManager = Bootstrap.Instance.ScoreManager;
            _resultSaver = Bootstrap.Instance.ResultsSaver;

            _timeManager.OnTick += UpdateTime;
            _timeManager.OnEndTime += EndGame;
            _scoreManager.OnUpdateScore += UpdateScore;
        }

        private void OnDestroy()
        {
            _timeManager.OnTick -= UpdateTime;
            _timeManager.OnEndTime -= EndGame;
            _scoreManager.OnUpdateScore -= UpdateScore;
        }

        private void UpdateScore(int _number) => _scoreView.CurrentScore = _number;
        private void UpdateTime(float _time) => _timeView.UpdateTime(_time);

        private void EndGame(float _time)
        {
            Time.timeScale = 0;

            _resultSaver.SaveCurrentResult(_time, _scoreView.CurrentScore);

            _gameOver.UpdateView(_time, _scoreView.CurrentScore);
            _gameOver.gameObject.SetActive(true);

            Debug.LogError("end");
        }

    }

    
}
