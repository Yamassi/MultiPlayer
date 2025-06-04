using UnityEngine;

namespace GameEngine
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;

        public void Move(Vector3 direction, float deltaTime)
        {
            transform.position += direction * (deltaTime * _speed);
        }
    }
}