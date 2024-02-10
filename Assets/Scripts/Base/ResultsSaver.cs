using BalloonProject.Data;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

namespace BalloonProject
{
    /// <summary>
    /// Сохранение результатов
    /// </summary>
    public class ResultsSaver : Saver
    {
        /// <summary>
        /// Данные сохранены
        /// </summary>
        public event Action OnSaveResults = delegate { };

        /// <summary>
        /// Ссылка на текущий результат
        /// </summary>
        public Result CurrentResult => _currentResult;

        private Result _currentResult;
        private Results _results = new Results();

        protected override void Awake()
        {
            base.Awake();
            Load();
        }

        public override void Load()
        {
            if (!File.Exists(savePath))
            {
                Debug.LogError("[Result] - Load - File not Found!");
                return;
            }

            try
            {
                string json = File.ReadAllText(savePath);

                Results _loadResultsJson = JsonUtility.FromJson<Results>(json);

                _results.ListAllResults = new List<Result>(_loadResultsJson.ListAllResults);
            }
            catch (Exception e)
            {
                Debug.LogError("[Result] - Load - " + e.Message);
            }
        }

        public override void Save()
        {
            string json = JsonUtility.ToJson(_results, true);

            try
            {
                File.WriteAllText(savePath, json);
                OnSaveResults();
            }
            catch (Exception e)
            {
                Debug.LogError("[Result] - Save - " + e.Message);
            }
        }

        public override void Removed()
        {
            //TODO: удаление
        }

        /// <summary>
        /// Записать последние результаты
        /// </summary>
        /// <param name="_time"> время игры </param>
        /// <param name="_score"> полученные очки </param>
        public void SaveCurrentResult(float _time, int _score, string _name = "No Name")
        {
            _currentResult = new Result();
            _currentResult.ID = DateTime.Now.ToString();
            _currentResult.Name = _name;
            _currentResult.Time = _time;
            _currentResult.Date = DateTime.Now.ToString();
            _currentResult.Score = _score;

            _results.ListAllResults.Add(_currentResult);

            Save();
        }

        public void SaveNameResult(string _id, string _name = "No Name")
        {
            foreach (var _result in _results.ListAllResults)
            {
                if (_result.ID == _id)
                {
                    _result.Name = _name;
                }
            }

            Save();
        }
    }
}
