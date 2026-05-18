using System;
using UnityEngine;

namespace _Project.Logic
{
    [Serializable]
    internal class CharacterControllerService
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _controller;

        public void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
            _controller.Move(direction * (_speed * Time.deltaTime));
        }
    }
}