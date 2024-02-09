using BalloonProject.Data;
using UnityEngine;
using System.IO;
using System;

namespace BalloonProject
{
    public class ResultSaver : MonoBehaviour, ISaver<Result>
    {
        [SerializeField] private string _savePath;
        [SerializeField] private string _saveFileName = "data.json";

        private Result _currentResult;

        public Result CUrrResult => _currentResult;

        private Results _Resultssss = new Results();

        private void Awake()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, _saveFileName);
#else
            _savePath = Path.Combine(Application.streamingAssetsPath, _saveFileName);
#endif
           //Load();
        }

        public void Load()
        {
            if (!File.Exists(_savePath))
            {
                Debug.LogError("[Result] - Load - File not Found!");
                return;
            }

            try
            {
                string json = File.ReadAllText(_savePath);

                //Result _loadResultsJson = JsonUtility.FromJson<Result>(json);
                //_currentResult.ID = _loadResultsJson.ID;
                //_currentResult.Name = _loadResultsJson.Name;
                //_currentResult.Time = _loadResultsJson.Time;
                //_currentResult.Date = _loadResultsJson.Date;
                //_currentResult.Score = _loadResultsJson.Score;

                //FiXME: список результатов
                Results _loadResultsJson = JsonUtility.FromJson<Results>(json);
                _Resultssss.AllResults = _loadResultsJson.AllResults;

            }
            catch (Exception e)
            {
                Debug.LogError("[Result] - Load - " + e.Message);
            }
        }

        public void Save(Result _currentResult)
        {
            Result _result = new Result();
            _result.ID = _currentResult.ID;
            _result.Name = _currentResult.Name;
            _result.Time = _currentResult.Time;
            _result.Date = _currentResult.Date;
            _result.Score = _currentResult.Score;

            //string json = JsonUtility.ToJson(_result, true);

            //FiXME: список результатов
            _Resultssss.AllResults.Add(_result);
            string json = JsonUtility.ToJson(_Resultssss, true);


            try
            {
                File.WriteAllText(_savePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError("[Result] - Save - " + e.Message);
            }

        }

        public void Removed()
        {
            //TODO: удаление
        }

        private void OnApplicationQuit() => Save(_currentResult);

        /// <summary>
        /// Записать последние результаты
        /// </summary>
        /// <param name="_time"></param>
        /// <param name="_score"></param>
        public void SetCurrentResult(float _time, int _score)
        {
            _currentResult = new Result();
            _currentResult.ID = DateTime.Now.ToString();
            _currentResult.Name = "Name Defalt";
            _currentResult.Time = _time;
            _currentResult.Date = DateTime.Now.ToString();
            _currentResult.Score = _score;
            Save(_currentResult);
        }
    }
}
