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
            Vector3 moveDirection = GetMoveDirection();

            _characterController.Move(moveDirection);
        }

        private Vector3 GetMoveDirection()
        {
            Vector2 input = _inputService.Moved;

            Vector3 forward = _playerCamera.Transform.forward;
            Vector3 right = _playerCamera.Transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            return (forward * input.y + right * input.x).normalized;
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