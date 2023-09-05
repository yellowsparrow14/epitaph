using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    public float currentBaseValue;
    public bool beneficial = true;
    public SN<float> maxValue = null;
    public SN<float> minValue = null;

    private List<StatModifier> modifiers;
    private bool _isDirty = true;
    private float modifiedValue;


    public ModifiableStat() {}

    public ModifiableStat(StatEnum name)
    {
        this.statName = name;
    }

    public ModifiableStat(StatEnum name, float value)
    {
        this.statName = name;
        this.intialValue = value;
        this.currentBaseValue = value;
    }

    public ModifiableStat(StatEnum name, float value, bool beneficial, float? maxValue, float? minValue)
    {
        this.statName = name;
        this.intialValue = value;
        this.currentBaseValue = value;
        this.beneficial = beneficial;
        this.maxValue = maxValue;
    }

    public float GetStatValue()
    {
        if(_isDirty) 
            modifiedValue = CalculateValue();
        return modifiedValue;
    }


    private float CalculateValue()
    {
        float baseVal = currentBaseValue;
        float add = 0;
        float multipliers = 1;
        float additivePercent = 0;

        modifiers.Sort();
        foreach(StatModifier m in modifiers)
        {
            switch(m.applicationType)
            {
                case ApplicationType.ADD:
                    add += m.amount;
                    break;

                case ApplicationType.MULTIPLY:
                    multipliers *= m.amount;
                    break;

                case ApplicationType.ADD_PERCENT:
                    additivePercent += m.amount;
                    break;

                case ApplicationType.SET:
                case ApplicationType.SET_AFFECTABLE:
                    baseVal = m.amount;
                    break;

                default:
                    break;
            }
        }

        baseVal = baseVal * multipliers * (1 + additivePercent) + add;

        if(minValue != null && baseVal < minValue) baseVal = HandleBelowMinValue(baseVal);
        if(maxValue != null && baseVal > maxValue) baseVal = HandleAboveMaxValue(baseVal);

        return baseVal;
    }

    private float HandleBelowMinValue(float value)
    {
        return minValue.HasValue ? minValue.Value : value;
    }

    private float HandleAboveMaxValue(float value)
    {
        return maxValue.HasValue ? maxValue.Value : value;
    }

    public void AddModifier(StatModifier modifier)
    {
        _isDirty = true;
        modifiers.Add(modifier);
    }

    public void RemoveModifier(StatEnum statEnum)
    {
        
    }

    public void RemoveModifier(StatModifier modifier)
    {
        _isDirty = true;
        modifiers.Remove(modifier);
    }

}

