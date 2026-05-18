using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Logic
{
    [RequireComponent(typeof(Camera))]
    internal class PlayerCamera : MonoBehaviour
    {
        private const float MinRotate = -90f;
        private const float MaxRotate = 90f;

        [SerializeField] private float _sensitivity;

        [field: SerializeField] public Transform Transform { get; private set; }

        private float _yaw;
        private float _pitch;

        private void Start() =>
            Cursor.lockState = CursorLockMode.Locked;

        private void LateUpdate() =>
            Transform.rotation = Quaternion.Euler(_pitch, _yaw, 0f);

        private void OnValidate()
        {
            if (Transform == null)
                Transform = GetComponent<Transform>();
        }

        public void OnLook(Vector2 look)
        {
            _yaw += look.x * _sensitivity;
            _pitch -= look.y * _sensitivity;
            _pitch = Mathf.Clamp(_pitch, MinRotate, MaxRotate);
        }
    }
}