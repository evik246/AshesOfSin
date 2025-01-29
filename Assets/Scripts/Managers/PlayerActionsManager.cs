using Assets.Scripts.Contracts.Managers;
using Assets.Scripts.Contracts.Services;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PlayerActionsManager : IPlayerActionsManager
    {
        private readonly IPLayerControlsRepository _playerControlsRepository;

        public PlayerActionsManager(IPLayerControlsRepository pLayerControlsRepository)
        {
            _playerControlsRepository = pLayerControlsRepository;
        }

        public void InitializeMovement(Rigidbody2D rb, float speed)
        {
            Vector2 lastDirection = Vector2.zero;
            Vector2 currentDirection = Vector2.zero;

            _playerControlsRepository.GetAction(PlayerActionType.Move).performed += ctx =>
            {
                Vector2 inputDirection = ctx.ReadValue<Vector2>();

                // Если нажаты противоположные клавиши — стоим
                if (Mathf.Approximately(inputDirection.x, 0) && Mathf.Approximately(inputDirection.y, 0))
                {
                    rb.linearVelocity = Vector2.zero;
                    return;
                }

                // Двигаемся в новое направление, если его приоритет выше
                if (Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y) || lastDirection.y == 1 || lastDirection.y == -1)
                {
                    currentDirection = new Vector2(Mathf.Sign(inputDirection.x), 0);
                }
                else
                {
                    currentDirection = new Vector2(0, Mathf.Sign(inputDirection.y));
                }

                lastDirection = inputDirection; // Запоминаем направление
                rb.linearVelocity = currentDirection * speed;
            };

            _playerControlsRepository.GetAction(PlayerActionType.Move).canceled += ctx =>
            {
                Vector2 inputDirection = ctx.ReadValue<Vector2>();

                // Если все клавиши отпущены — персонаж останавливается
                if (Mathf.Approximately(inputDirection.x, 0) && Mathf.Approximately(inputDirection.y, 0))
                {
                    rb.linearVelocity = Vector2.zero;
                    lastDirection = Vector2.zero; // Сбрасываем направление
                    return;
                }

                // Если текущая ось движения отпущена, переключаемся на другую ось (если клавиша ещё зажата)
                if (lastDirection.x != 0 && !Mathf.Approximately(inputDirection.x, 0))
                {
                    currentDirection = new Vector2(Mathf.Sign(inputDirection.x), 0);
                }
                else if (lastDirection.y != 0 && !Mathf.Approximately(inputDirection.y, 0))
                {
                    currentDirection = new Vector2(0, Mathf.Sign(inputDirection.y));
                }
                else
                {
                    currentDirection = lastDirection;
                }

                lastDirection = inputDirection;
                rb.linearVelocity = currentDirection * speed;
            };
        }

        public void InitializeInteraction()
        {
            _playerControlsRepository.GetAction(PlayerActionType.Interact).performed += _ =>
            {
                Debug.Log("Игрок взаимодействует с объектом!");
            };
        }
    }
}
