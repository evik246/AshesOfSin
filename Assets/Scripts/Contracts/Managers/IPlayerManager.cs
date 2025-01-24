using UnityEngine;

namespace Assets.Scripts.Contracts.Managers
{
    /// <summary>
    /// Менеджер, управляющего вводом и действиями игрока.
    /// </summary>
    public interface IPlayerManager
    {
        /// <summary>
        /// Инициализирует управление передвижением.
        /// </summary>
        /// <param name="rb">Персонаж игрока.</param>
        /// <param name="speed">Скорость передвижения.</param>
        void InitializeMovement(Rigidbody2D rb, float speed);

        /// <summary>
        /// Инициализирует управление взаимодействием.
        /// </summary>
        void InitializeInteraction();
    }
}
