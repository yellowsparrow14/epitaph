using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health : ModifiableStat
{
    private Entity _entity;

    public float health => CalculateValue();

    public Health(Entity entity)
    {
        statName = StatEnum.HEALTH;
        minValue = 0;
        _entity = entity;
    }

    public Health(Entity entity, float value)
    {
        intialValue = value;
        currentBaseValue = value;
        statName = StatEnum.HEALTH;
        minValue = 0;
        _entity = entity;
    }

    public void TakeDamage(float amount)
    {
        Damage damage = new(amount);
        AddModifier(damage);
    }

    public void Heal(float amount)
    {
        Heal heal = new(amount);
        AddModifier(heal);
    }

    protected override float HandleBelowMinValue(float value)
    {
        Die();
        return 0;
    }

    private void Die() 
    {
        _entity.Die();
    }
}
