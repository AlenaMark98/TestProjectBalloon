using BalloonProject.Data;
using BalloonProject.View;
using System;
using System.Collections;
using UnityEngine;

namespace BalloonProject
{

    /// <summary>
    /// Менеджер времени уровня
    /// </summary>
    public class TimerManager : MonoBehaviour
    {
        /// <summary>
        /// Время окончено 
        /// </summary>
        public event Action<float> OnEndTime = delegate { };
        /// <summary>
        /// Обновлено время
        /// </summary>
        public event Action<float> OnTick = delegate { };

        [SerializeField]
        private TimeView _timeView;

        private float _durationSeconds;
        private float _currentTime;

        private Coroutine _timer;

        private void OnDisable()
        {
            if (_timer != null)
            {
                StopCoroutine(_timer);
            }
        }

        /// <summary>
        /// Начать отчет
        /// </summary>
        public void StartTimer(float _duration)
        {
            SetDuration(_duration);
            _timer = StartCoroutine(ITimer());
        }

        private void SetDuration(float _duration)
        {
            _durationSeconds = _duration;
            _currentTime = _durationSeconds;
        }

        private IEnumerator ITimer()
        {
            while (_currentTime <= _durationSeconds && _currentTime > 0)
            {
                _currentTime --;
                OnTick(_currentTime);

                yield return new WaitForSeconds(1);
            }

            OnEndTime(_durationSeconds);
        }

    }
}
