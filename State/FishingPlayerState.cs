using Animals.Player.Controller;
using UnityEngine;

namespace Animals.StateMachine.Player
{
    public class FishingPlayerState : PlayerController, IPlayerState
    {
        public IPlayerState DoState(BaseStateMachine player)
        {
            PlayerMoving(player);

            if (EnteredDefaultState(player))
            {
                return player.defaultPlayerState;
            }

            else
            {
                Debug.Log("Changed player state");
                return player.fishingPlayerState;
            }
        }

        public void StartFishing(BaseStateMachine player)
        {
            player.variableJoystick.AxisOptions = AxisOptions.Horizontal;
        }

        public override void PlayerMoving(BaseStateMachine player)
        {
            StartFishing(player);
        }

        private bool EnteredDefaultState(BaseStateMachine player)
        {
            bool triggerIsActive = false;

            if (player.triggerDefault.activeSelf)
            {
                triggerIsActive = true;
            }
            return triggerIsActive;
        }
    }
}