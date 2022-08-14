using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Abilities;
using RPG.Control;
using System;

namespace RPG.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "Self Targeting", menuName = "Abilities/Targeting/Self Targeting", order = 0)]
    public class SelfTargeting : TargetingStrategy
    {
        public override void StartTargeting(AbilityData data, Action finished)
        {
            data.SetTargets(new GameObject[]{data.GetUser()});
            data.SetTargetedPoint(data.GetUser().transform.position);
            finished();
        }

    }
}
