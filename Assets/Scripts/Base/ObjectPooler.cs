using System.Collections.Generic;
using UnityEngine;
using BalloonProject.Data;

namespace BalloonProject.PoolObject
{
    /// <summary>
    /// Пул объект
    /// </summary>
    [System.Serializable]
    public class Pool
    {
        //TODO: Переделать на общий тип пул
        /// <summary>
        /// Тег объекта
        /// </summary>
        public string Tag;
        /// <summary>
        /// Объект для спавна
        /// </summary>
        public ObjectSpawn ObjectSpawn;
    }

    /// <summary>
    /// Пулер объектов
    /// </summary>
    public sealed class ObjectPooler : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на экземпляр класса
        /// </summary>
        public static ObjectPooler Instance = default;

        [SerializeField] 
        private List<Pool> _pools;
        /// <summary>
        /// Ссылка на экземпляр пулов
        /// </summary>
        public IReadOnlyList<Pool> Pools => _pools;

        /// <summary>
        /// Созданные пул объекты
        /// </summary>
        public List<ObjectSpawn> _listAllPoolInScene = new List<ObjectSpawn>();

        private bool _inactiveObjectPresent = false;

        private void Awake() => Instance = this;

        /// <summary>
        /// Включить объекты из пула или создать новый
        /// </summary>
        /// <param name="_tag"> Тег объектов </param>
        /// <param name="_position"> Начальная позиция </param>
        /// <param name="_rotation"> Поворот объекта </param>
        /// <param name="_transform"> Родитель объекта </param>
        public void SpawnPoolObject(string _tag, Vector2 _position, Quaternion _rotation, Transform _transform)
        {
            _inactiveObjectPresent = false;

            for (int i = 0; i < _listAllPoolInScene.Count; i++)
            {
                if (_tag == _listAllPoolInScene[i].ID && !_listAllPoolInScene[i].isActiveAndEnabled)
                {
                    _listAllPoolInScene[i].gameObject.transform.position = _position;
                    _listAllPoolInScene[i].gameObject.transform.rotation = _rotation;
                    _listAllPoolInScene[i].gameObject.SetActive(true);

                    UpdatePoolObjectFunctions(_listAllPoolInScene[i]);

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
                        GameObject _gameObj = Instantiate(_pool.ObjectSpawn.gameObject, _position, _rotation, _transform);
                        ObjectSpawn _objSpawn = _gameObj.GetComponent<ObjectSpawn>();

                        UpdatePoolObjectFunctions(_objSpawn);
                        _listAllPoolInScene.Add(_objSpawn);
                    }
                    
                }
            }

        }

        private void UpdatePoolObjectFunctions(ObjectSpawn _objSpawn)
        {
            IPoolObject _poolObject = _objSpawn.GetComponent<IPoolObject>();
            if (_poolObject != null)
            {
                _poolObject.OnSpawnPoolObject();
            }
        }


    }
}