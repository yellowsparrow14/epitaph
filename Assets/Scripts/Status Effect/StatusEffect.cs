using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
