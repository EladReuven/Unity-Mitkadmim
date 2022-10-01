using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Data.Save
{
    [System.Serializable]
    public class SaveFields
    {
        public Vector3 savedPlayerVector3;
        public int savedPlayerHealth;

        public List<Vector3> savedEnemiesV3;
        public List<int> savedEnemiesHealth;
    }
}

