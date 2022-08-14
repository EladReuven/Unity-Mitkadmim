using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class AttackReleaseState : PlayerState
    {
        public float holdTime = 0;
        public override void Update()
        {
            
        }

        public AttackReleaseState(float holdTime)
        {
            this.holdTime = holdTime;
        }
    }
}
