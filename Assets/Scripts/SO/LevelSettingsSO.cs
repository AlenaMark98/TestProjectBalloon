using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// настройки уровня
    /// </summary>
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "BalloonProject/LevelSettingsSO", order = 51)]
    public class LevelSettingsSO : ScriptableObject
    {
        [SerializeField] private float _duration;

        /// <summary>
        /// Время для отчета 
        /// </summary>
        public float Duration => _duration;
    }
}
