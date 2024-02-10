using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonProject.View
{
    /// <summary>
    /// ������ ����
    /// </summary>
    [System.Serializable]
    public class UIScreen
    {
        /// <summary>
        /// ��� �������
        /// </summary>
        public string Id;
        /// <summary>
        /// ������ ��� ������
        /// </summary>
        public GameObject ScreenPrefab;
    }

    /// <summary>
    /// ������������ ����
    /// </summary>
    public class SwitchScreens : MonoBehaviour
    {
        [SerializeField] private List<UIScreen> _screens = new List<UIScreen>();

        /// <summary>
        /// �������� ������ ����
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

