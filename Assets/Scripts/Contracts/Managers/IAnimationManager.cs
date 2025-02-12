using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contracts.Managers
{
    public interface IAnimationManager
    {
        void MoveAnimation(Animator animator,
            AnimationClip moveLeft,
            AnimationClip moveRight,
            AnimationClip moveUp,
            AnimationClip moveDown);

        void IdleAnimation(
            Animator animator,
            AnimationClip idle
            //IEnumerable<AnimationClip> additionalIdles
            );
    }
}
