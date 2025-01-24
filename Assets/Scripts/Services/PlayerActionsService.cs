using Assets.Scripts.Contracts.Services;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class PlayerActionsService : IPlayerActionsService
    {
        public void Move(Rigidbody2D playerRigidbody, Vector2 direction, float moveSpeed)
        {
            playerRigidbody.linearVelocity = direction * moveSpeed;
        }

        public void Interact()
        {
            Debug.Log("Игрок взаимодействует с объектом!");
        }
    }
}
