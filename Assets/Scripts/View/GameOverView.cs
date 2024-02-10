using UnityEngine;
using UnityEngine.UI;

namespace BalloonProject
{
    /// <summary>
    /// Отображение окончания игры
    /// </summary>
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private InputField _inputField = default;
        [SerializeField] private Text _textTime = default;
        [SerializeField] private Text _textScore = default;
        [SerializeField] private Button _buttonSave = default;

        private ResultsSaver _resultSaver = default;

        private string _score = default;
        private string _time = default;

        private void Awake()
        {
            _buttonSave.onClick.AddListener(Save);

            _resultSaver = Bootstrap.Instance.ResultsSaver;
        }

        private void OnEnable()
        {
            _textTime.text = _time;
            _textScore.text = _score;
        }

        private void OnDestroy() => _buttonSave.onClick.RemoveListener(Save);

        private void Save() => _resultSaver.SaveNameResult(_resultSaver.CurrentResult.ID, _inputField.text);

        /// <summary>
        /// Обновить данные отображения
        /// </summary>
        /// <param name="_time"> время </param>
        /// <param name="_score"> счет </param>
        public void UpdateView(float _time, int _score)
        {
            //FIXME: Исправить формат времени
            this._time = "00 : " + _time.ToString();
            this._score = _score.ToString();
        }

    }
}
