using System;
using UnityEngine;

namespace _Project.Logic
{
    internal class NewInputService : IDisposable
    {
        private readonly InputSystem_Actions _actions = new();

        public NewInputService() => 
            _actions.Enable();
        
        public Vector2 Moved => _actions.Player.Move.ReadValue<Vector2>();
        
        public void Dispose() => 
            _actions?.Disable();
    }
}