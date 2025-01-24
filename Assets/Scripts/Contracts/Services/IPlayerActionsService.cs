using UnityEngine;

namespace Assets.Scripts.Contracts.Services
{
    /// <summary>
    /// Сервис игровых действий игрока.  
    /// Определяет основные действия, которые может выполнять персонаж игрока.
    /// </summary>
    public interface IPlayerActionsService
    {
        /// <summary>
        /// Двигает персонажа игрока в указанном направлении.
        /// </summary>
        /// <param name="playerRigidbody">Персонаж игрока.</param>
        /// <param name="direction">Направление движения.</param>
        /// <param name="moveSpeed">Скорость передвижения.</param>
        void Move(Rigidbody2D playerRigidbody, Vector2 direction, float moveSpeed);

        /// <summary>
        /// Выполняет взаимодействие с объектами.
        /// </summary>
        void Interact();
    }
}
