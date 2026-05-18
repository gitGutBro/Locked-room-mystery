using System;
using UnityEngine;

namespace _Project.Logic
{
    [RequireComponent(typeof(CharacterController))]
    internal class Player : MonoBehaviour
    {
        [SerializeField] private CharacterControllerService _characterController;
        
        private NewInputService _inputService;

        private void Awake() => 
            _inputService = new NewInputService();

        private void Update()
        {
            Vector2 input = _inputService.Moved;
            
            _characterController.Move(input);
        }

        private void OnDestroy() => 
            _inputService?.Dispose();
    }
}