using System;
using UnityEngine;

namespace _Project.Logic
{
    internal class NewInputService : IDisposable
    {
        private readonly InputSystem_Actions _actions = new();

        public NewInputService()
        {
            _actions.Enable();
            
            _actions.Player.Look.performed += callbackContext => Look?.Invoke(callbackContext.ReadValue<Vector2>());
            _actions.Player.Look.canceled += _ => Look?.Invoke(Vector2.zero);
        }

        public event Action<Vector2> Look; 
            
        public Vector2 Moved => _actions.Player.Move.ReadValue<Vector2>();
        
        public void Dispose() => 
            _actions?.Disable();
    }
}