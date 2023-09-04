using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatEnum
{
    HEALTH,
    WALKSPEED,    
}

[System.Serializable]
public class ModifiableStat
{
    public StatEnum statName;
    public float intialValue;
    public float currentValue;
    public bool beneficial = true;
    public float? maxValue = null;
    public float? minValue = null;

    public List<StatModifier> modifiers;

    public ModifiableStat(StatEnum name, float value)
    {
        this.statName = name;
        this.intialValue = value;
        this.currentValue = value;
    }

    public ModifiableStat(StatEnum name, float value, bool beneficial, float? maxValue, float? minValue)
    {
        this.statName = name;
        this.intialValue = value;
        this.currentValue = value;
        this.beneficial = beneficial;
        this.maxValue = maxValue;
    }
}

//C: Put any stats you want on every entity here. These are the stats that can be modified by status effects
[System.Serializable]
public class EntityStats
{
    public List<ModifiableStat> stats = new List<ModifiableStat>()
    {
        new(StatEnum.HEALTH, 100),
        new(StatEnum.WALKSPEED, 5),
    };
}
