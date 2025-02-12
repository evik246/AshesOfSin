using Assets.Scripts.Contracts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UnityScripts
{
    [RequireComponent(typeof(Animator))]
    public class MoveAnimationScript : MonoBehaviour
    {
        private Animator animator;

        [SerializeField]
        private AnimationClip idle;

        [SerializeField]
        private AnimationClip moveLeft;

        [SerializeField]
        private AnimationClip moveRight;

        [SerializeField]
        private AnimationClip moveUp;

        [SerializeField]
        private AnimationClip moveDown;

        private IAnimationManager _playerAnimationManager;

        [Inject]
        private void Construct(
            IAnimationManager playerAnimationManager)
        {
            _playerAnimationManager = playerAnimationManager;
        }

        public void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Update()
        {
            _playerAnimationManager.MoveAnimation(animator, moveLeft, moveRight, moveUp, moveDown);
            _playerAnimationManager.IdleAnimation(animator, idle);
        }
    }
}
