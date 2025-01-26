using Assets.Scripts.Contracts.Services;
using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Repositories
{
    /// <summary>
    /// Реализация репозитория управления, использующего Unity Input System.
    /// </summary>
    public class PlayerControlsRepository : IPLayerControlsRepository
    {
        private readonly PlayerInputActions _playerInput;
        private Dictionary<PlayerActionType, InputAction> _actions;

        public PlayerControlsRepository()
        {
            _playerInput = new PlayerInputActions();
            _actions = new Dictionary<PlayerActionType, InputAction>
            {
                { PlayerActionType.Move, _playerInput.Player.Move },
                { PlayerActionType.Interact, _playerInput.Player.Interact }
            };
            _playerInput.Enable();
        }

        public void Dispose()
        {
            _playerInput.Disable();
        }

        public void SetBinding(PlayerActionType action, string newBindingPath)
        {
            var inputAction = GetAction(action);
            inputAction.ApplyBindingOverride(newBindingPath);
        }

        public string GetBinding(PlayerActionType action)
        {
            return GetAction(action).bindings[0].effectivePath;
        }

        public InputAction GetAction(PlayerActionType action)
        {
            return _actions[action];
        }
    }
}
