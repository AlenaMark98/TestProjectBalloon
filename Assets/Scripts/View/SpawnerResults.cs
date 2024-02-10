using BalloonProject.PoolObject;
using System.Collections.Generic;
using UnityEngine;
using BalloonProject.View;

namespace BalloonProject
{
    /// <summary>
    /// Спавнер результатов
    /// </summary>
    public class SpawnerResults : MonoBehaviour
    {
        [SerializeField] private ResultView _resultPrefab;
        private ResultsSaver _resultSaver = default;

        private List<ResultView> _resultsViewInScene = new List<ResultView>();

        private void Awake() => _resultSaver = FindObjectOfType<ResultsSaver>();

        private void OnEnable() => SpawnResults();

        private void SpawnResults()
        {
            //FIXME: Реализовать pool
            foreach (var _result in _resultsViewInScene)
            {
                Destroy(_result.gameObject);
            }

            foreach (var _result in _resultSaver.Results.ListAllResults)
            {
                GameObject _gameObj = Instantiate(_resultPrefab.gameObject, transform.position, Quaternion.identity, transform);

                ResultView _resultSpawn = _gameObj.GetComponent<ResultView>();
                _resultSpawn.DisplayResult(_result);

                _resultsViewInScene.Add(_resultSpawn);
            }

        }
    }
}
