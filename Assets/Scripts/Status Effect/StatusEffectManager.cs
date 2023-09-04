using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StatusEffectManager : MonoBehaviour
{
    private List<StatusEffectInstance> _statusEffects = new List<StatusEffectInstance>();
    private List<StatusEffectCode> _statusEffectTypes = new List<StatusEffectCode>();

    private Entity _entity;

    private bool _hasListChanged = false;

    private float _currTime;

    private void Start() {
        _entity = this.gameObject.GetComponent<Entity>();
        if(_entity == null) Debug.LogError("Status Effect maanger applied to an object with no entity class. This should not happen");
    }

    private void Update() {
        _currTime = Time.time;
        TickStatusEffects();
        UpdateEffectList();
    }


    private void TickStatusEffects()
    {
        for (int i = 0; i < _statusEffects.Count; i++) {
            StatusEffectInstance se = _statusEffects[i];
            if (se.statusEffect.tickStatusEffect != null) {   
                if(_currTime > se.nextTickTime) {
                    se.nextTickTime = _currTime + se.statusEffect.tickTime;
                    //se.TickEffect();
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

    private void ClearExpiredEffects()
    {

    }


    public void AddEffect(StatusEffectInstance effect)
    {
        //C TODO: how do we want to handle effects that already exist?
        //For now, I am assuming each effect code is only used once
        StatusEffect se = effect.statusEffect;

        if(_statusEffectTypes.Contains(se.effectCode)) {
            StatusEffectInstance currEffect = _statusEffects.Where( s => s.statusEffect.effectCode == se.effectCode).First();
            if(effect.expirationTime > currEffect.expirationTime)
            {
                currEffect.expirationTime = effect.expirationTime;
            }
        } 
        else {
            _statusEffects.Add(effect);
            effect.expirationTime = _currTime + se.duration;
            effect.nextTickTime = _currTime + se.tickTime;
        }
    }

    public void RemoveEffect(StatusEffectCode code)
    {
        StatusEffectInstance effectInstance = _statusEffects.Where( s => s.statusEffect.effectCode == code).First();
        RemoveEffect(effectInstance);
    }

    public void RemoveEffect(StatusEffect effect)
    {
        StatusEffectInstance effectInstance = _statusEffects.Where( s => s.statusEffect == effect).First();
        RemoveEffect(effectInstance);
    }

    public void RemoveEffect(StatusEffectInstance effect)
    {

    }

}
