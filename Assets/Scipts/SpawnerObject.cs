using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BalloonProject.Data;

namespace BalloonProject
{
    /// <summary>
    /// Спавнер объектов для взаимодействия с игроком
    /// </summary>
    public class SpawnerObject : MonoBehaviour
    {
        [SerializeField] private RectTransform _startTargetSpawnObject = default;

        private float _minX, _maxX, _minY, _maxY;
        private ObjectPooler _objectPooler;
        private Coroutine _timerSpawnObjects;

        void Start()
        {
            _objectPooler = ObjectPooler.Instance;
            SetStartPosition();
        }

        private void FixedUpdate()
        {
            if (_timerSpawnObjects == null)
            {
                _timerSpawnObjects = StartCoroutine(Spawn());
            }

        }

        private void SetStartPosition()
        {
            _minX = 0;
            _maxX = _startTargetSpawnObject.rect.width;
            _minY = _startTargetSpawnObject.position.y - _startTargetSpawnObject.rect.height / 2;
            _maxY = _startTargetSpawnObject.position.y + _startTargetSpawnObject.rect.height / 2;

            Debug.Log(_minX + " " + _maxX + "    " + _minY + " " + _maxY);
        }

        private void SpawnObject()
        {
            Vector2 _position = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            //NOTE: Возможен вариант добавления процента вывода определнных значений
            int _numberObj = Random.Range(0, _objectPooler.Pools.Count);

            _objectPooler.SpawnObject(_objectPooler.Pools[_numberObj].Tag, _position, Quaternion.identity);

            StopCoroutine(_timerSpawnObjects);
            _timerSpawnObjects = null;
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(1f);
            SpawnObject();
        }
    }
}