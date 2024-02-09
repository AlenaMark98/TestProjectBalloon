using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BalloonProject.Data
{
    /// <summary>
    /// ¬оздушный шар
    /// </summary>
    public class Balloon : ObjectSpawn, IPoolObject, IPointerDownHandler
    {
        private Vector2 _directionUP = new Vector2(0, 1f);

        private Rigidbody2D _rb = default;
        private Animator _animator = default;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate() => Move(_directionUP);

        public override void Move(Vector2 _directionMove) => _rb.MovePosition(_rb.position + _directionMove * Speed);

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "RespawnObject")
            {
                gameObject.SetActive(false);
            }
        }

        public void OnSpawnPoolObject() => Speed = Random.Range(MinSpeed, MaxSpeed);

        private void Bang() => gameObject.SetActive(false);

        //NOTE: не разделен контроллер от даты
        public void OnPointerDown(PointerEventData eventData)
        {
            _animator.SetTrigger("Bang");
            Bootstrap.Instance.ScoreManager.UpdateScore(Point);
        }
    }
}
