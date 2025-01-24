using Assets.Scripts.Contracts.Managers;
using Assets.Scripts.Managers;
using UnityEngine;

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
        private IPlayerManager _playerManager;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerManager = new PlayerManager();
            _playerManager.InitializeMovement(_rb, speed);
        }
    }
}
