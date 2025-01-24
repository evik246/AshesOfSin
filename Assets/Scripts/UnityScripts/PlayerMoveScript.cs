

using UnityEngine;

namespace Assets.Scripts.UnityScripts
{
    public class PlayerMoveScript : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector2 direction;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
