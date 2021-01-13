using UnityEngine;
using Animals.Player.Controller;

namespace Animals.StateMachine.Player
{
    public abstract class PlayerController : PlayerController
    {
        public abstract void PlayerMoving(BaseStateMachine player);
    }
}