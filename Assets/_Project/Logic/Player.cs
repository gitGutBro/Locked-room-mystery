using UnityEngine;

namespace _Project.Logic
{
    [RequireComponent(typeof(CharacterController))]
    internal class Player : MonoBehaviour
    {
        [SerializeField] private CharacterControllerService _characterController;
        [SerializeField] private PlayerCamera _playerCamera;
        
        private NewInputService _inputService;

        private void Awake()
        {
            _inputService = new NewInputService();
            _inputService.Look += _playerCamera.OnLook;
        }

        private void Update()
        {
            Vector2 input = _inputService.Moved;
            
            _characterController.Move(input);
        }

        private void OnDestroy()
        {
            if (_inputService == null)
                return;
            
            _inputService.Look -= _playerCamera.OnLook;
            _inputService.Dispose();
        }
    }
}