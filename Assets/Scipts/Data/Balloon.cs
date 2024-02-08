using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonProject.Data
{
    /// <summary>
    /// Воздушный шар
    /// </summary>
    public class Balloon : ObjectSpawn, IPoolObject
    {
        private float _speedMin = 0.5f;
        private float _speedMax = 2.01f;

        private Vector2 _directionUP = new Vector2(0, 1f);

        private void Update() => Move(_directionUP);

        public override void Move(Vector2 _directionMove)
        {
            Vector3 _direction = new Vector3(_directionMove.x, _directionMove.y, 0);
            transform.Translate(_direction * Speed, Space.Self);
        }

        private void OnCollisionStay2D(Collision2D _collision)
        {
            Debug.Log(_collision.collider.tag == "RespawnObject");
            if (_collision.collider.tag == "RespawnObject")
            {
                gameObject.SetActive(false);
            }
        }

        public void OnObjectSpawn() => Speed = Random.Range(_speedMin, _speedMax);
    }
}