using UnityEngine;

namespace GameEngine
{
    public class MovementInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public Vector2 GetMovementInput()
        {
            float horizontal = Input.GetAxisRaw(HorizontalAxis);
            float vertical = Input.GetAxisRaw(VerticalAxis);
            return new Vector2(horizontal, vertical);
        }
    }
}