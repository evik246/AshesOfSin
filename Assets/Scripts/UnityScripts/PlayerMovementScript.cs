using Assets.Scripts.Contracts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UnityScripts
{
    /// <summary>
    /// Компонент управления передвижением игрока.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementScript : MonoBehaviour
    {
        public float speed = 5f;

        private Rigidbody2D _rb;
        private IPlayerActionsManager _playerActionsManager;

        [Inject]
        private void Construct(IPlayerActionsManager playerActionsManager)
        {
            _playerActionsManager = playerActionsManager;
        } 

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerActionsManager.InitializeMovement(_rb, speed);
        }
    }
}
