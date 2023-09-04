using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    //StatusEffectManager is used to controll all status effects on an entity. 

    private List<StatusEffect> _statusEffects = new List<StatusEffect>();
    private Entity _entity;

    private void Start() {
        _entity = this.gameObject.GetComponent<Entity>();
        if(_entity == null) Debug.LogError("Status Effect maanger applied to an object with no entity class. This should not happen");
    }

    private void Update() {
        TickStatusEffects();
        UpdateEffectList();
    }


    private void TickStatusEffects()
    {
        for (int i = 0; i < _statusEffects.Count; i++) {
            StatusEffect se = _statusEffects[i];
            if (se.tickStatusEffect != null) {   
                if(Time.time > se.lastTickTime + se.tickSpeed) {
                    se.lastTickTime = Time.time;
                    se.TickEffect();
                }
            }
        }
    }

    // C: see https://www.reddit.com/r/gamedev/comments/50rrcs/code_design_for_an_ability_status_effect_system/
    // for why this is implemented this way
    
    private void UpdateEffectList()
    {
        throw new NotImplementedException();
    }

}
