using Animals.AnimatorController.Player;
using Animals.Player.Controller;
using Animals.StateMachine.Player;
using Animals.Utilities;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Animals.StateMachine
{
    public class BaseStateMachine : Singleton<BaseStateMachine>
    {
        public DefaultPlayerState defaultPlayerState = new DefaultPlayerState();
        public FishingPlayerState fishingPlayerState = new FishingPlayerState();

        public static Action OnPlayerJump;

        public Rigidbody rb;
        public CapsuleCollider capsuleCollider;

        public GameObject triggerFishing, triggerDefault;

        public float speed, maxSpeed;
        public float jumpPower;

        [HideInInspector] public DefaultPlayerAnimation defaultPlayerAnimation;
        [HideInInspector] public VariableJoystick variableJoystick;

        private IPlayerState currentState;

        //limit jump power while player moving
        public float JumpPower
        {
            get
            {   
                if (rb.velocity.magnitude < 1) { return jumpPower / 1.5f; }
                else { return jumpPower;}
            }
        }

        private void OnEnable()
        {
            defaultPlayerAnimation = FindObjectOfType<DefaultPlayerAnimation>();
            variableJoystick = FindObjectOfType<VariableJoystick>();

            currentState = defaultPlayerState;
        }

        private void Update()
        {                                   
            currentState = currentState.DoState(this);
        }
    }
}