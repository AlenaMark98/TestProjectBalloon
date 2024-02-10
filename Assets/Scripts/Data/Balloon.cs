using UnityEngine;
using UnityEngine.EventSystems;
using BalloonProject.PoolObject;

namespace BalloonProject.Data
{
    /// <summary>
    /// Воздушный шар
    /// </summary>
    public class Balloon : ObjectSpawn, IPoolObject, IPointerDownHandler
    {
        private Vector2 _directionUP = new Vector2(0, 1f);

        private Rigidbody2D _rb = default;
        private Animator _animator = default;

        private ScoreManager _scoreManager = default;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            _scoreManager = Bootstrap.Instance.ScoreManager;
        }

        private void FixedUpdate() => Move(_directionUP);

        public override void Move(Vector2 _directionMove) => _rb.AddForce( _directionMove.normalized * Speed, ForceMode2D.Impulse);

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "RespawnObject")
            {
                gameObject.SetActive(false);
            }
        }

        public void OnSpawnPoolObject() => Speed = Random.Range(MinSpeed, MaxSpeed);

        private void Bang() => gameObject.SetActive(false);

        public void OnPointerDown(PointerEventData eventData)
        {
            _animator.SetTrigger("Bang");
            _scoreManager.UpdateScore(Point);
        }
    }
}
