using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// Данные объекта для спавна
    /// </summary>
    [CreateAssetMenu(fileName = "ObjectSpawnSO", menuName = "BalloonProject/ObjectSpawnSO", order = 51)]
    public class ObjectSpawnSO : ScriptableObject
    {
        [SerializeField] private string _id = "Object";
        [SerializeField] private int _point = 1;
        [SerializeField] private float _minSpeed = 3f;
        [SerializeField] private float _maxSpeed = 6f;

        /// <summary>
        /// ID объекта
        /// </summary>
        public string ID => _id;

        /// <summary>
        /// Очки за объект 
        /// </summary>
        public int Point => _point;

        /// <summary>
        /// Минимальная скорость
        /// </summary>
        public float MinSpeed => _minSpeed;

        /// <summary>
        /// Максимальная скорокть
        /// </summary>
        public float MaxSpeed => _maxSpeed;
    }
}