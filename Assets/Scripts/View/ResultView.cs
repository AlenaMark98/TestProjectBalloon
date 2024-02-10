using System;
using UnityEngine;
using UnityEngine.UI;
using BalloonProject.Data;
using BalloonProject.PoolObject;

namespace BalloonProject.View
{
    /// <summary>
    /// Вьющка результатов
    /// </summary>
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private InputField _inputField = default;
        [SerializeField] private Text _time = default;
        [SerializeField] private Text _date = default;
        [SerializeField] private Text _score = default;

        private Result _result = default;
        private ResultsSaver _resultSaver = default;

        private void Awake()
        {
            _resultSaver = FindObjectOfType<ResultsSaver>();
            _inputField.onValueChanged.AddListener(Save);
        }

        private void OnDestroy() => _inputField.onValueChanged.RemoveListener(Save);

        private void Save(string _name) => _resultSaver.SaveNameResult(_result.ID, _name);

        /// <summary>
        /// Отобразить данные результа
        /// </summary>
        /// <param name="_result"></param>
        public void DisplayResult(Result _result)
        {
            this._result = _result;
            _inputField.text = _result.Name;
            _time.text = "00 : " + _result.Time.ToString();
            _date.text = _result.Date.ToString();
            _score.text = _result.Score.ToString();
        }
    }
}
