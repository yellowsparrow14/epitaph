using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectApplicator : MonoBehaviour
{
    public List<StatusEffect> statusEffects = new List<StatusEffect>(); 

    public void ApplyEffects(StatusEffectManager target)
    {
        foreach(StatusEffect se in statusEffects)
        {
            StatusEffectInstance effect = new StatusEffectInstance();
            effect.statusEffect = se;
            target.AddEffect(effect);
        }
    }
}
