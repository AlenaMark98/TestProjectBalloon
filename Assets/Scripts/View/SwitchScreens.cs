using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonProject.View
{
    /// <summary>
    /// Данные окна
    /// </summary>
    [System.Serializable]
    public class UIScreen
    {
        /// <summary>
        /// Тег объекта
        /// </summary>
        public string Id;
        /// <summary>
        /// Объект для спавна
        /// </summary>
        public GameObject ScreenPrefab;
    }

    /// <summary>
    /// Переключение окон
    /// </summary>
    public class SwitchScreens : MonoBehaviour
    {
        [SerializeField] private List<UIScreen> _screens = new List<UIScreen>();

        /// <summary>
        /// Включить нужное окно
        /// </summary>
        /// <param name="_idScreen"></param>
        public void SwitchScreen(string _idScreen)
        {
            foreach (var screen in _screens)
            {
                screen.ScreenPrefab.SetActive(_idScreen == screen.Id);
            }
        }

    }
}

