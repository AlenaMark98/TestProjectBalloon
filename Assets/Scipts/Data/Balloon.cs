using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonProject.Data
{

    /// <summary>
    /// ¬оздушный шар
    /// </summary>
    public class Balloon : ObjectSpawn
    {
        void Update()
        {
            //Move(new Vector2(0f, 10f));
        }

        public override void Move(Vector2 _directionMove)
        {
            Vector3 _direction = new Vector3(_directionMove.x, _directionMove.y, 0);

            //Fixme: исправитьскорость движени€
            _direction.Normalize();
            transform.Translate(_direction * Speed * Time.deltaTime, Space.World);

        }

    }
}