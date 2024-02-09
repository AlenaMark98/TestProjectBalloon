using UnityEngine;
using UnityEngine.UI;

namespace BalloonProject.View
{

    /// <summary>
    /// Вьюшка для таймера
    /// </summary>
    public class TimeView : MonoBehaviour
    {
        private Text _time = default;

        private void Awake() => _time = GetComponent<Text>();

        /// <summary>
        /// Обновить время
        /// </summary>
        /// <param name="_currentTime"> текущее время</param>
        public void UpdateTime(float _currentTime)
        {
            _time.text =  "00 : " + _currentTime.ToString();
        }
    }
}
