using Animals.Player.Data;
using Animals.StateMachine;
using UnityEngine;

namespace Animals.AnimatorController.Player
{
    public class DefaultPlayerAnimation : BaseAnimatorController
    {
        [HideInInspector] public BaseStateMachine stateMachine;
        [HideInInspector] public Animator animator;

        private void Start()
        {
            stateMachine = GetComponentInParent<BaseStateMachine>();
            animator = GetComponent<Animator>();

            BaseStateMachine.OnPlayerJump += PlayerJumpAnimation;
            Debug.Log("Subscribed on jump event");
        }

        public void PlayerJumpAnimation()
        {
            SetAnimatorProperty(() => animator.SetBool("Jump", true));
        }

        public void PlayerMovingAnimation()
        {
            SetAnimatorProperty(() => animator.SetFloat("Speed", stateMachine.rb.velocity.magnitude));
        }

        public void PlayerInteractAnimation()
        {
            SetAnimatorProperty(() => animator.SetTrigger(PlayerData.Instance.interactionAnimation));
        }

        private void OnDisable()
        {
            BaseStateMachine.OnPlayerJump -= PlayerJumpAnimation;
        }
    }
}