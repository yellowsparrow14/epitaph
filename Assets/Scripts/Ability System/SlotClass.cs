using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotClass
{
    private Ability ability;
    
    public SlotClass (Ability ability) {
        this.ability = ability;
    }

    public Ability GetAbility() {
        return ability;
    }
    
}
