using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitAugment : Augment
{
    public virtual float applyAugmentDamageTaken(float damageTaken, Entity current, Entity target)
    {
        // used in AugmentManager to actually apply
        return 0;
    }

    public virtual float applyAugmentDamageDealt(float damageDealt, Entity current, Entity target)
    {
        // used in AugmentManager to actually apply
        return 0;
    }
}
