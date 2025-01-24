﻿using Assets.Scripts.Contracts.Managers;
using Assets.Scripts.Contracts.Services;
using Assets.Scripts.Models;
using Assets.Scripts.Repositories;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly IPLayerControlsRepository _controlsRepository;
        private readonly IPlayerActionsService _actionsService;

        public PlayerManager()
        {
            _controlsRepository = new PlayerControlsRepository();
            _actionsService = new PlayerActionsService();
        }

        // TODO: Исправить баги логики перемещения
        public void InitializeMovement(Rigidbody2D rb, float speed)
        {
            Vector2 lastDirection = Vector2.zero;
            Vector2 currentDirection = Vector2.zero;

            _controlsRepository.GetAction(PlayerActionType.Move).performed += ctx =>
            {
                Vector2 inputDirection = ctx.ReadValue<Vector2>();

                // Если нажаты противоположные клавиши — стоим
                if (Mathf.Approximately(inputDirection.x, 0) && Mathf.Approximately(inputDirection.y, 0))
                {
                    _actionsService.Move(rb, Vector2.zero, speed);
                    return;
                }

                // Двигаемся в новое направление, если его приоритет выше
                if (Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y) || lastDirection.y != 0)
                {
                    currentDirection = new Vector2(Mathf.Sign(inputDirection.x), 0);
                }
                else
                {
                    currentDirection = new Vector2(0, Mathf.Sign(inputDirection.y));
                }

                lastDirection = currentDirection; // Запоминаем направление
                _actionsService.Move(rb, currentDirection, speed);
            };

            _controlsRepository.GetAction(PlayerActionType.Move).canceled += ctx =>
            {
                Vector2 inputDirection = ctx.ReadValue<Vector2>();

                // Если все клавиши отпущены — персонаж останавливается
                if (Mathf.Approximately(inputDirection.x, 0) && Mathf.Approximately(inputDirection.y, 0))
                {
                    _actionsService.Move(rb, Vector2.zero, speed);
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

                lastDirection = currentDirection;
                _actionsService.Move(rb, currentDirection, speed);
            };
        }

        public void InitializeInteraction()
        {
            // Удерживание клавиш для взаимодействия
            _controlsRepository.GetAction(PlayerActionType.Interact).performed += _ =>
            {
                _actionsService.Interact();
            };
        }
    }
}
