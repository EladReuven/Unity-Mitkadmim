using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    [System.Serializable]
    public abstract class PlayerState
    {
        public abstract void Update();
    }

}
