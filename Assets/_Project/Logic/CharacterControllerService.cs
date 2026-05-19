using System;
using UnityEngine;

namespace _Project.Logic
{
    [Serializable]
    internal class CharacterControllerService
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _controller;

        public void Move(Vector3 direction) => 
            _controller.Move(direction * (_speed * Time.deltaTime));
    }
}