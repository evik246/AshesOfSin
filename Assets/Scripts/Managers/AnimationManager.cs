using Assets.Scripts.Contracts.Managers;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AnimationManager : IAnimationManager
    {
        public string currentState;
        
        private void ChangeAnimationState(Animator animator, string newstate)
        {
            if (currentState == newstate) return;
           
            animator.Play(newstate);

            currentState = newstate;
        }

        public void MoveAnimation(
            Animator animator, 
            AnimationClip moveLeft, 
            AnimationClip moveRight, 
            AnimationClip moveUp, 
            AnimationClip moveDown)
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");
            if (xAxis < 0)
            {
                ChangeAnimationState(animator, moveLeft.name);
            }
            else if (xAxis > 0)
            {
                ChangeAnimationState(animator, moveRight.name);
            }
            else if (yAxis < 0)
            {
                ChangeAnimationState(animator, moveDown.name);
            }
            else if (yAxis > 0)
            {
                ChangeAnimationState(animator, moveUp.name);
            }
            
        }

        public void IdleAnimation(
            Animator animator, 
            AnimationClip idle
            //IEnumerable<AnimationClip> additionalIdles
            )
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");

            if (xAxis == 0 && yAxis == 0)
            {
                ChangeAnimationState(animator, idle.name);
            }
        }
    }
}
