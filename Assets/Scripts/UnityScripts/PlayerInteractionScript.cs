using Assets.Scripts.Contracts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UnityScripts
{
    /// <summary>
    /// Компонент управления взаимодействием игрока.
    /// </summary>
    public class PlayerInteractionScript : MonoBehaviour
    {
        private IPlayerActionsManager _playerActionsManager;

        [Inject]
        private void Construct(IPlayerActionsManager playerActionsManager)
        {
            _playerActionsManager = playerActionsManager;
        }

        private void Start()
        {
            _playerActionsManager.InitializeInteraction();
        }
    }
}
