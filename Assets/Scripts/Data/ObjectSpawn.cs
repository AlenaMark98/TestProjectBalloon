using System;
using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// Объект для спавна
    /// </summary>
    public abstract class ObjectSpawn : MonoBehaviour
    {
        [SerializeField] private ObjectSpawnSO _objectSpawnSO = default;

        /// <summary>
        /// Изменен Тег объекта
        /// </summary>
        public event Action OnChangedTag = delegate { };
        /// <summary>
        /// Изменение очков за объект
        /// </summary>
        public event Action OnChangedPoint = delegate { };
        /// <summary>
        /// Изменение скорокти объекта
        /// </summary>
        public event Action OnChangedSpeed = delegate { };

        /// <summary>
        /// Тег объекта
        /// </summary>
        public string Tag
        {
            get => _tag;
            set
            {
                if (value != _tag)
                {
                    _tag = value;
                    OnChangedTag();
                }
            }
        }
        
        /// <summary>
        /// Очки за объект (начисление/вычетание)
        /// </summary>
        public int Point
        {
            get => _point;
            set
            {
                if (value != _point)
                {
                    _point = value;
                    OnChangedPoint();
                }
            }
        }

        /// <summary>
        /// Скороть движения объекта
        /// </summary>
        public float Speed
        {
            get => _speed;
            set
            {
                if (value != _speed)
                {
                    _speed = value;
                    OnChangedSpeed();
                }
            }
        }

        /// <summary>
        /// Объект проинициализирован
        /// </summary>
        public bool IsInit() => _init;

        private string _tag = default;
        private int _point = default;
        private float _speed = default;

        private bool _init = false;

        protected virtual void Awake() => Init();

        /// <summary>
        /// Инициализация объекта
        /// </summary>
        protected virtual void Init()
        {
            if (_objectSpawnSO != null)
            {
                Tag = _objectSpawnSO.Tag;
                Point = _objectSpawnSO.Point;
                Speed = 0.5f;
                _init = true;
            }
            else
            {
                Debug.LogError("ObjectSpawn not Init!");
            }
        }

        /// <summary>
        /// Перемещение объекта
        /// </summary>
        public abstract void Move(Vector2 _directionMove);
    }
}