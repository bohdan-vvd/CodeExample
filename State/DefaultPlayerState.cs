using UnityEngine;
using Animals.Player.Controller;

namespace Animals.StateMachine.Player
{
    public class DefaultPlayerState : PlayerController, IPlayerState
    {
        public IPlayerState DoState(BaseStateMachine player)
        {
            DoDefaultPlayerMoving(player);

            if (EnteredInFishingState(player))
            {
                return player.fishingPlayerState;
            }

            else
            {
                Debug.Log("Changed player state");
                return player.defaultPlayerState;
            }
        }

        private void DoDefaultPlayerMoving(BaseStateMachine player)
        {
            PlayerMoving(player);
            player.defaultPlayerAnimation.PlayerMovingAnimation();

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump(player);
            }
#endif
        }
        
        public void PlayerJump(BaseStateMachine player)
        {
            RaycastHit hit;

            if (Physics.Raycast(player.transform.position, -Vector3.up, out hit, 1.1f))
            {
                player.rb.AddForce(Vector3.up * player.JumpPower * Time.deltaTime, ForceMode.Impulse);
                BaseStateMachine.OnPlayerJump?.Invoke();
                Debug.Log("Player jumped, raycast hit ground ");
            }

            else
            {
                Debug.Log("Player not on the ground");
            }
        }

        public override void PlayerMoving(BaseStateMachine player)
        {
            player.variableJoystick.AxisOptions = AxisOptions.Both;

            Vector3 movingDirection = Vector3.forward * player.variableJoystick.Vertical + Vector3.right * player.variableJoystick.Horizontal;
            Vector3 rotationDirection = Vector3.forward * player.variableJoystick.rotationVertical + Vector3.right * player.variableJoystick.rotationHorizontal;

            player.rb.AddForce(movingDirection * player.speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        private bool EnteredInFishingState(BaseStateMachine player)
        {
            bool triggerIsActive = false;

            if (player.triggerFishing)
            {
                triggerIsActive = true;
            }
           
            return triggerIsActive;
        }
    }
}