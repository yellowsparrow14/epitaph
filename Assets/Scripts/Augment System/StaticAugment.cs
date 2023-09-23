using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAugment : Augment
{

    private Entity recipient = null;

    public virtual void applyAugment(Entity entity) {
        recipient = entity;
        throw new NotImplementedException("You need to implement a function to start this augment!");
    }

    public virtual void removeAugment() {
        throw new NotImplementedException("You need to implement a function to remove this augment!");
    }

}
