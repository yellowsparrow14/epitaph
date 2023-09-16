using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitAugment : Augment
{
    public virtual float applyAugmentDamageTaken(float damageTaken)
    {
        // used in AugmentManager to actually apply
        return 0;
    }

    public virtual float applyAugmentDamageDealt(float damageDealt)
    {
        // used in AugmentManager to actually apply
        return 0;
    }
}
