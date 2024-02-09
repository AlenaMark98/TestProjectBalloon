using System.Collections.Generic;
using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// Спавнер результатов
    /// </summary>
    public class SpawnerResults : MonoBehaviour
    {
        [SerializeField] private ResultView _resultPrefab;

        private List<ResultView> _resultsViewInScene = new List<ResultView>();

        private List<Result> _results;

        private void Awake()
        {
            Bootstrap.Instance.ResultSaver.Load();
        }

        private void OnEnable()
        {
            SpawnResults();
        }

        private void LoadResults()
        {
            //_results = new List<Result>();
        }

        private void SpawnResults()
        {
            //FiXME: спавн списка
            GameObject _gameObj = Instantiate(_resultPrefab.gameObject, transform.position, Quaternion.identity, transform);
            Result re = Bootstrap.Instance.ResultSaver.CUrrResult;
            ResultView _resultSpawn = _gameObj.GetComponent<ResultView>();
            _resultSpawn.DisplayResult(re);

        }
    }
}
