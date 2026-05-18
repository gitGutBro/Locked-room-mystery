using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace _Project.Logic
{
    internal class DialogueService : MonoBehaviour
    {
        [SerializeField] private PlayerCamera _playerCamera;
        
        // Don't change names and signatures "OnConversationStart" and "OnConversationEnd"
        private void OnConversationStart(Transform actor)
        {
            _playerCamera.enabled = false;
            
            Transform conversant = DialogueManager.CurrentConversant;

            if (conversant is null)
                FocusAtConversant(conversant);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void OnConversationEnd(Transform actor)
        {
            _playerCamera.enabled = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void FocusAtConversant(Transform conversant)
        {
            Vector3 direction = conversant.position - _playerCamera.Transform.position;
            _playerCamera.Transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}