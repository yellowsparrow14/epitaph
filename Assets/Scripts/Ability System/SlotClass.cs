using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private Ability ability;
    
    public SlotClass() {
        ability = null;
    }

    public SlotClass (Ability ability) {
        this.ability = ability;
    }

    public SlotClass (SlotClass slot) {
        this.ability = slot.GetAbility();
    }

    public Ability GetAbility() {
        return ability;
    }
    
    public void AddAbility(Ability ability) {
        this.ability = ability;
    }

    public void Clear() {
        this.ability = null;
    }
}
