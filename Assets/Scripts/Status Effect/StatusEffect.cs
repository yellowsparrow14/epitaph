using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//abstract out cooldown stuff

[System.Serializable]
public enum StatusEffectApplicationType
{
    ADD,
    MULTIPLY,
    SET,
};
[System.Serializable]
public class StatModifier
{
    public StatusEffectApplicationType applicationType;
    public StatEnum stat;
    public float amount;
}
[CreateAssetMenu]
public class StatusEffect : ScriptableObject
{
    public string effectName;
    public float tickSpeed;
    public float lifeTime;

    //C: Do not put passive status effects (ie +5 attack damage)
    // on entry, tick, or exit events. It will not work.

    public List<StatModifier> entryStatusEffect = new List<StatModifier>(); //Applied once on entry
    public List<StatModifier> passiveStatusEffect = new List<StatModifier>(); //Applied permanently  
    public List<StatModifier> tickStatusEffect = new List<StatModifier>(); //Applied at every tick
    public List<StatModifier> exitStatusEffect = new List<StatModifier>(); //Applied once on exit



    public float effectAmount;
    public float DOTAmount;
    public float currentEffectTime;
    
    public float lastTickTime;


    public void TickEffect()
    {
        //
    }




    // public void HandleEffect(Entity entity)
    // {
    //     currentEffectTime += Time.deltaTime;
    //     if (currentEffectTime >= lifeTime) {
    //         //entity.RemoveEffect();
    //         return;
    //     }
  
    //     if (DOTAmount != 0 && currentEffectTime > lastTickTime + tickSpeed) {
    //         lastTickTime = currentEffectTime; 
    //         entity.TakeDamage(DOTAmount);
    //     }
    // }


    // public bool HasExpired (float currTime) {
    //     if (currTime > _expiryTime) return true;
    //     return false;
    // }
 
 
    // public void SetTickedTime (float t) {
    //     _nextTickTime = t;
    // }
}
