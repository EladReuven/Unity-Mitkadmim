using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class IdleState : PlayerState
    {
        public override void Update()
        {
            //The idle state do nothing on it's own
            //It's only use is to be a defualt state
        }
    }
}
