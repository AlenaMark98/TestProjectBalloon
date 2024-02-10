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
        /// <summary>
        /// Данные сохранены
        /// </summary>
        public event Action OnSaveResults = delegate { };
        
        /// <summary>
        /// Cсылка на класс
        /// </summary>
        public static Bootstrap Instance;

        [SerializeField] private LevelSettingsSO _levelSettings = default;
        [SerializeField] private TimerManager _timeManager = default;
        [SerializeField] private ScoreManager _scoreManager = default;
        [SerializeField] private UIManager _uiManager = default;
        //TODO: Нужнен менеджер
        [SerializeField] private SpawnerObject _spawnerObject = default;
        
        private ResultsSaver _resultsSaver = default;

        /// <summary>
        /// Ссылка на экземляр класса
        /// </summary>
        public LevelSettingsSO LevelSettings => _levelSettings;
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
        public ResultsSaver ResultsSaver => _resultsSaver;
        /// <summary>
        /// Сссылка на экземляр класса
        /// </summary>
        public UIManager UIManager => _uiManager;

        private void Awake()
        {
            Instance = this;
            _resultsSaver = FindObjectOfType<ResultsSaver>();
        }

        private void Start()
        {
            _spawnerObject.StartSpawn();
            _uiManager.UpdateTime(_levelSettings.Duration);
            _timeManager.StartTimer(_levelSettings.Duration);
            
        }

    }
}
