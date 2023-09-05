using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//C: Put any stats you want on every entity here. These are the stats that can be modified by status effects
[System.Serializable]
public class EntityStats
{
    public Health health = new Health();
    [SerializeField] private List<ModifiableStat> stats = new()
    {
        new(StatEnum.WALKSPEED, 5),
    };


    public float GetStatValue(StatEnum stat)
    {
        ModifiableStat s = stats.Where(s => s.statName == stat).First();
        return GetModifiedStat(s, null);
    }

    public float GetHealth()
    {
        return GetModifiedStat(health, null);
    }

    private float GetModifiedStat(ModifiableStat stat, List<StatModifier> modifiers)
    {
        float baseVal = stat.currentBaseValue;
        modifiers.Sort();
        foreach(StatModifier m in modifiers)
        {
            switch(m.applicationType)
            {
                case ApplicationType.ADD:
                    baseVal += m.amount;
                    break;

                case ApplicationType.MULTIPLY:
                    baseVal *= m.amount;
                    break;

                case ApplicationType.SET:
                case ApplicationType.SET_AFFECTABLE:
                    baseVal = m.amount;
                    break;

                default:
                    break;
            }
        }

        if(stat.minValue != null && baseVal < stat.minValue) baseVal = (float) stat.minValue;
        if(stat.maxValue != null && baseVal > stat.maxValue) baseVal = (float) stat.maxValue;

        return baseVal;
    }
}
