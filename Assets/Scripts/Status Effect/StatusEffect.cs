using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ApplicationType
{
    NONE,
    SET, //Will be applied last, so will override other multipliers
    ADD,
    MULTIPLY,
    SET_AFFECTABLE, //Will be applied first, so can be affected by other multipliers
};

[System.Serializable]
public class StatModifier
{
    public readonly ApplicationType applicationType;
    public readonly StatEnum stat;
    public readonly float amount;
    public readonly bool beneficial; 
}

[CreateAssetMenu]
public class StatusEffect : ScriptableObject
{
    public readonly StatusEffectCode effectCode;
    public readonly float tickTime;
    public readonly float duration;

    public enum RemovableType { Removable, NonRemovable };
    public enum ExpirableType { Expirable, NonExpireable };

    //C: Do not put passive status effects (ie +5 attack damage)
    // on entry, tick, or exit events. It will not work.
    public readonly List<StatModifier> entryStatusEffect = new List<StatModifier>(); //Applied once on entry
    public readonly List<StatModifier> passiveStatusEffect = new List<StatModifier>(); //Applied permanently  
    public readonly List<StatModifier> tickStatusEffect = new List<StatModifier>(); //Applied at every tick
    public readonly List<StatModifier> exitStatusEffect = new List<StatModifier>(); //Applied once on exit
}
