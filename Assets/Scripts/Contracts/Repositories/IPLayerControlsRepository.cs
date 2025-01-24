using Assets.Scripts.Models;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Contracts.Services
{
    /// <summary>
    /// Репозиторий управления игрока.  
    /// Позволяет получать и изменять клавиши управления.
    /// </summary>
    public interface IPLayerControlsRepository
    {
        /// <summary>
        /// Устанавливает новую клавишу для указанного действия.
        /// </summary>
        /// <param name="action">Игровое действие.</param>
        /// <param name="newBindingPath">Новый путь ввода (например, "Keyboard/W").</param>
        void SetBinding(PlayerActionType action, string newBindingPath);

        /// <summary>
        /// Получает текущую клавишу для указанного действия.
        /// </summary>
        /// <param name="action">Игровое действие.</param>
        /// <returns>Строковый путь к текущей клавише.</returns>
        string GetBinding(PlayerActionType action);

        /// <summary>
        /// Получает InputAction для указанного действия.
        /// </summary>
        /// <param name="action">Игровое действие.</param>
        /// <returns>Объект InputAction.</returns>
        InputAction GetAction(PlayerActionType action);
    }
}
