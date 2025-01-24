using Assets.Scripts.Contracts.Managers;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.UnityScripts
{
    /// <summary>
    /// Компонент управления взаимодействием игрока.
    /// </summary>
    public class PlayerInteractionScript : MonoBehaviour
    {
        private IPlayerManager _playerManager;

        private void Start()
        {
            _playerManager = new PlayerManager();
            _playerManager.InitializeInteraction();
        }
    }
}
