using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
        /// Изменение скорокти объекта
        /// </summary>
        public event Action OnChangedSpeedMin = delegate { };
        /// <summary>
        /// Изменение скорокти объекта
        /// </summary>
        public event Action OnChangedSpeedMax = delegate { };

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
        /// Скороть минимального движения объекта
        /// </summary>
        public float MinSpeed
        {
            get => _minSpeed;
            set
            {
                if (value != _minSpeed)
                {
                    _minSpeed = value;
                    OnChangedSpeedMin();
                }
            }
        }
        /// <summary>
        /// Скороть Маскимального движения объекта
        /// </summary>
        public float MaxSpeed
        {
            get => _maxSpeed;
            set
            {
                if (value != _maxSpeed)
                {
                    _maxSpeed = value;
                    OnChangedSpeedMax();
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
        private float _minSpeed = default;
        private float _maxSpeed = default;

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
                MinSpeed = _objectSpawnSO.MinSpeed;
                MaxSpeed = _objectSpawnSO.MaxSpeed;
                Speed = Random.Range(MinSpeed, MaxSpeed);
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