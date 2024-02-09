using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BalloonProject.PoolObject;

namespace BalloonProject
{
    /// <summary>
    /// Спавнер объектов для взаимодействия с игроком
    /// </summary>
    public sealed class SpawnerObject : MonoBehaviour
    {
        [SerializeField] private RectTransform _startTargetSpawnObject;
        [SerializeField] private float _timeAfterWhichToSpawnObject = 0.5f;

        private ObjectPooler _objectPooler = default;
        private Coroutine _timerSpawnObjects = default;
        private float _minX = 0, _maxX = 0, _minY = 0, _maxY = 0;

        private bool _isStartSpawn = false;

        private void Start()
        {
            _objectPooler = ObjectPooler.Instance;
            SetStartPosition(_startTargetSpawnObject);
        }

        private void FixedUpdate()
        {
            if (_isStartSpawn && _timerSpawnObjects == null)
            {
                _timerSpawnObjects = StartCoroutine(Spawn());
            }
        }

        private void OnDisable()
        {
            if (_timerSpawnObjects != null)
            { 
                StopCoroutine(_timerSpawnObjects);
            }
        }

        /// <summary>
        /// Начать спавн объектов
        /// </summary>
        public void StartSpawn() => _isStartSpawn = true;

        private void SetStartPosition(RectTransform _startRect)
        {
            _minX = 0;
            _maxX = Screen.width;
            _minY = _startRect.position.y - _startRect.rect.height / 2;
            _maxY = _startRect.position.y + _startRect.rect.height / 2;
        }

        private void SpawnObject()
        {
            Vector2 _position = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            
            //NOTE: можно добавить процент выпадения определнных значений
            int _numberObj = Random.Range(0, _objectPooler.Pools.Count);

            _objectPooler.SpawnPoolObject(_objectPooler.Pools[_numberObj].Tag, _position, Quaternion.identity, transform);

            StopCoroutine(_timerSpawnObjects);
            _timerSpawnObjects = null;
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(_timeAfterWhichToSpawnObject);
            SpawnObject();
        }
    }
}