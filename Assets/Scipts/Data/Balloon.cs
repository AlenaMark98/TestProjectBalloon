using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// Пул объект
    /// </summary>
    public interface IPoolObject
    {
        /// <summary>
        /// Вызван пул объект
        /// </summary>
        public void OnObjectSpawn();
    }

    /// <summary>
    /// Воздушный шар
    /// </summary>
    public class Balloon : ObjectSpawn, IPoolObject
    {
        private Vector2 _directionUP = new Vector2(0, 1f);

        void Update()
        {
            Move(_directionUP);
        }

        public override void Move(Vector2 _directionMove)
        {
            Vector3 _direction = new Vector3(_directionMove.x, _directionMove.y, 0);
            transform.Translate(_direction * Speed, Space.Self);
        }

        private void OnCollisionStay2D(Collision2D _collision)
        {
            Debug.Log(_collision.collider.tag == "Finish");
            if (_collision.collider.tag == "Finish")
            {
                gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Вызван пул объект
        /// </summary>
        public void OnObjectSpawn()
        {
            Speed = Random.Range(0.5f, 2f);
        }
    }
}