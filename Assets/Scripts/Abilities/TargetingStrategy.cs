using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace RPG.Abilities
{
    public abstract class TargetingStrategy : ScriptableObject
    {
        public abstract void StartTargeting(AbilityData data, Action finished);
    }

}
