using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class AttackHoldState : PlayerState
    {
        public float holdTime = 0;
        public override void Update()
        {
            holdTime += Time.deltaTime;
        }
    }
}
