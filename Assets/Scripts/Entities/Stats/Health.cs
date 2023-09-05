using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health : ModifiableStat
{
    public Health()
    {
        statName = StatEnum.HEALTH;
    }
}
