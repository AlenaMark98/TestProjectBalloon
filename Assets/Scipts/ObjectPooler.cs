using System.Collections.Generic;
using UnityEngine;
using BalloonProject.Data;

namespace BalloonProject
{
    /// <summary>
    /// Пул объект
    /// </summary>
    [System.Serializable]
    public class Pool
    {
        /// <summary>
        /// Тег объекта
        /// </summary>
        public string Tag;
        /// <summary>
        /// Объект для спавна
        /// </summary>
        public ObjectSpawn ObjectSpawn;
        /// <summary>
        /// Количество объектов, которое нужно создать
        /// </summary>
        public int NumberOfObjects;
    }

    /// <summary>
    /// Пулер объектов
    /// </summary>
    public class ObjectPooler : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на экземпляр класса
        /// </summary>
        public static ObjectPooler Instance;

        [SerializeField] private List<Pool> _pools;
        public IReadOnlyList<Pool> Pools => _pools;

        /// <summary>
        /// Созданные пул объекты
        /// </summary>
        public Dictionary<string, Queue<ObjectSpawn>> _poolDictionary = new Dictionary<string, Queue<ObjectSpawn>>();

        /// <summary>
        /// Созданные пул объекты
        /// </summary>
        public List<ObjectSpawn> _listAllPoolInScene = new List<ObjectSpawn>();

        private void Awake()
        {
            Instance = this;
            
            _poolDictionary = new Dictionary<string, Queue<ObjectSpawn>>();
        }

        private void SpawnAllObjects()
        {
            foreach (Pool _pool in _pools)
            {
                Queue<ObjectSpawn> _objectPool = new Queue<ObjectSpawn>();

                for (int i = 0; i < _pool.NumberOfObjects; i++)
                {
                    GameObject _gameObj = Instantiate(_pool.ObjectSpawn.gameObject, new Vector2(0, 0), Quaternion.identity, transform);
                    _gameObj.SetActive(false);
                    _objectPool.Enqueue(_gameObj.GetComponent<ObjectSpawn>());
                }

                _poolDictionary.Add(_pool.Tag, _objectPool);
            }
        }

        /// <summary>
        /// Включать объекты из пула
        /// </summary>
        /// <param name="_tag"> Тег объектов </param>
        /// <param name="_position"> Начальная позиция </param>
        /// <param name="_rotation"> Поворот объекта </param>
        /// <returns> спавн объект </returns>
        public ObjectSpawn SpawnFromPool(string _tag, Vector2 _position, Quaternion _rotation)
        {
            Debug.Log(_tag + "  " + _poolDictionary.ContainsKey(_tag));
            if (!_poolDictionary.ContainsKey(_tag))
            {
                Debug.LogWarning("Not tag");
                return null;
            }

            ObjectSpawn _objectToSpawn = _poolDictionary[_tag].Dequeue();

            _objectToSpawn.gameObject.SetActive(true);
            _objectToSpawn.gameObject.transform.position = _position;
            _objectToSpawn.gameObject.transform.rotation = _rotation;

            IPoolObject _poolObject = _objectToSpawn.GetComponent<IPoolObject>();
            if (_poolObject != null)
            {
                _poolObject.OnObjectSpawn();
            }

            _poolDictionary[_tag].Enqueue(_objectToSpawn);

            return _objectToSpawn;
        }

        /// <summary>
        /// Включать объекты из пула
        /// </summary>
        /// <param name="_tag"> Тег объектов </param>
        /// <param name="_position"> Начальная позиция </param>
        /// <param name="_rotation"> Поворот объекта </param>
        public void SpawnObject(string _tag, Vector2 _position, Quaternion _rotation)
        {
            bool _inactiveObjectPresent = false;

            for (int i = 0; i < _listAllPoolInScene.Count; i++)
            {
                if (_tag == _listAllPoolInScene[i].Tag && !_listAllPoolInScene[i].isActiveAndEnabled)
                {
                    _listAllPoolInScene[i].gameObject.transform.position = _position;
                    _listAllPoolInScene[i].gameObject.transform.rotation = _rotation;
                    _listAllPoolInScene[i].gameObject.SetActive(true);

                    IPoolObject _poolObject = _listAllPoolInScene[i].GetComponent<IPoolObject>();
                    if (_poolObject != null)
                    {
                        _poolObject.OnObjectSpawn();
                    }

                    _inactiveObjectPresent = true;

                    break;
                }
            }

            if (!_inactiveObjectPresent)
            {
                foreach (Pool _pool in _pools)
                {
                    if (_pool.Tag == _tag)
                    {
                        GameObject _gameObj = Instantiate(_pool.ObjectSpawn.gameObject, _position, _rotation, transform);
                        ObjectSpawn _objSpawn = _gameObj.GetComponent<ObjectSpawn>();

                        IPoolObject _poolObject = _objSpawn.GetComponent<IPoolObject>();
                        if (_poolObject != null)
                        {
                            _poolObject.OnObjectSpawn();
                        }

                        _listAllPoolInScene.Add(_objSpawn);
                    }
                    
                }
            }


        }

    }
}