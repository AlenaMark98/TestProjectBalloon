using BalloonProject.Data;
using System;
using UnityEngine;

namespace BalloonProject
{
    /// <summary>
    /// Последовательность загрузки
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        public event Action OnSaveResults = delegate { };
        
        /// <summary>
        /// Cсылка на класс
        /// </summary>
        public static Bootstrap Instance;

        [SerializeField] private LevelSettingsSO _levelSettings = default;
        [SerializeField] private TimerManager _timeManager = default;
        [SerializeField] private ScoreManager _scoreManager = default;
        //FiXME: менеджеры вместо спавнеров
        [SerializeField] private SpawnerObject _spawnerObject = default;
        [SerializeField] private ResultSaver _saveManager = default;

        /// <summary>
        /// Ссылка на экземляр класса
        /// </summary>
        public TimerManager TimerManager => _timeManager;
        /// <summary>
        /// Сссылка на экземляр класса
        /// </summary>
        public ScoreManager ScoreManager => _scoreManager;
        /// <summary>
        /// Сссылка на экземляр класса
        /// </summary>
        public ResultSaver ResultSaver => _saveManager;

        private void Awake() => Instance = this;

        private void Start()
        {
            _timeManager.StartTimer(_levelSettings.Duration);
            _spawnerObject.StartSpawn();
        }

        private void OnEnable() => _timeManager.OnEndTime += EndGame;

        private void OnDisable() => _timeManager.OnEndTime -= EndGame;

        //FiXME: выполнениять в другом месте =
        private void EndGame(float _time)
        {
            Time.timeScale = 0;
            //FiXME: выполнить в другом классе
            ResultSaver.SetCurrentResult(_levelSettings.Duration, _scoreManager.CurrentScore);
            OnSaveResults();
            Debug.LogError("end");
        }
    }
}
