using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class MoveState : PlayerState
    {
        public Vector2 movement;
        public MoveState(Vector2 movement)
        {
            this.movement = movement;
        }
        public override void Update()
        {
            
        }
    }
}
