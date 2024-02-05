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
        [SerializeField]
        private int _numberSpawnObjectScene = 10;

        [SerializeField] private RectTransform _targetSpawnObject;

        [SerializeField] private List<ObjectSpawn> _listObjectSpawnsPrefabs;

        [SerializeField] private List<ObjectSpawn> _listObjectSpawnsInScene = new List<ObjectSpawn>();

        /// <summary>
        /// Список всех созданных объектов на сцене
        /// </summary>
        public IReadOnlyList<ObjectSpawn> ListObjectSpawnsInScene => _listObjectSpawnsInScene;


        private float _minX, _maxX, _minY, _maxY;
        private Vector2 _pos;
        

        void Start()
        {
            SetMinAndMAx();
            InstantiateObject(_numberSpawnObjectScene);
        }

        void Update()
        {

        }

        private void SetMinAndMAx()
        {
            //Fixme: исправить координаты
            Vector2 _bounds = new Vector2(_targetSpawnObject.rect.width / 2, _targetSpawnObject.rect.height / 2);
            Debug.Log(_bounds);
            _minX = -_bounds.x;
            _maxX = _bounds.x;
            _minY = -_bounds.y;
            _maxY = _bounds.y;

            Debug.Log(_minX + " " + _maxX + "    " + _minY + " " + _maxY);
        }

        private void InstantiateObject(int _numberObjScene)
        {

            for (int i = 0; i < _numberObjScene; i++)
            {
                int _numberObject = Random.Range(0, _listObjectSpawnsPrefabs.Count);
                _pos = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));

                GameObject _balloonGO = Instantiate(_listObjectSpawnsPrefabs[_numberObject].gameObject, _pos, Quaternion.identity, _targetSpawnObject);

                Debug.Log(_balloonGO + "  " + _pos);

                if (_balloonGO != null)
                {
                    _listObjectSpawnsInScene.Add(_listObjectSpawnsPrefabs[0]);
                }
            
            }
        }
    }
}