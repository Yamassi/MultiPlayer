using System;
using Fusion;
using GameEngine;
using UnityEngine;

namespace Networking
{
    public class InputPopulator : MonoBehaviour
    {
        [SerializeField] private MovementInput _movementInput;

        [SerializeField] private NetworkCallbackReceiver _callbackReceiver;

        private void OnEnable() => 
            _callbackReceiver.OnPopulateInput += PopulateInput;

        private void OnDisable() => 
            _callbackReceiver.OnPopulateInput -= PopulateInput;

        private void PopulateInput(NetworkRunner runner, NetworkInput input)
        {
            NetworkInputData inputData = new()
            {
                MovementInput = _movementInput.GetMovementInput()
            };

            input.Set(inputData);
        }
    }
}