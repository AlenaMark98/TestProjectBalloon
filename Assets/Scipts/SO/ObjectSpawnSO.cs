﻿using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// Данные объекта для спавна
    /// </summary>
    [CreateAssetMenu(fileName = "ObjectSpawnSO", menuName = "BalloonProject/ObjectSpawnSO", order = 51)]
    public class ObjectSpawnSO : ScriptableObject
    {
        [SerializeField] private string _tag = "Object";
        [SerializeField] private int _point = 1;
        [SerializeField] private float _speed = 0.1f;

        /// <summary>
        /// Категория объекта
        /// </summary>
        public string Tag => _tag;

        /// <summary>
        /// Очки за объект 
        /// </summary>
        public int Point => _point;

        /// <summary>
        /// Скорость объекта 
        /// </summary>
        public float Speed => _speed;
    }
}