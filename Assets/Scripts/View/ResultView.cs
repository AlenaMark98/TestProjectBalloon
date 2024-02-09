using UnityEngine;
using UnityEngine.UI;

namespace BalloonProject.Data
{
    /// <summary>
    /// Вьющка результатов
    /// </summary>
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private Text Name;
        [SerializeField] private Text Time;
        [SerializeField] private Text Date;
        [SerializeField] private Text Score;

        private Result _result;
        //FiXME: 
        public Result Result => _result;

        /// <summary>
        /// Отобразить данные результа
        /// </summary>
        /// <param name="_result"></param>
        public void DisplayResult(Result _result)
        {
            this._result = _result;
            Name.text = _result.Name;
            Time.text = _result.Time.ToString();
            Date.text = _result.Date.ToString();
            Score.text = _result.Score.ToString();
        }
    }
}
