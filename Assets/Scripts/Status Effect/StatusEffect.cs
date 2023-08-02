using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//abstract out cooldown stuff
[CreateAssetMenu]
public class StatusEffect : ScriptableObject
{
    public string name;
    public float tickSpeed;
    public float lifeTime;
    public float effectAmount;
    public float DOTAmount;
    public float currentEffectTime;
    public float lastTickTime;

    public void HandleEffect(Entity entity)
    {
        currentEffectTime += Time.deltaTime;
        if (currentEffectTime >= lifeTime) {
            entity.RemoveEffect();
            return;
        }

        if (DOTAmount != 0 && currentEffectTime > lastTickTime + tickSpeed) {
            lastTickTime = currentEffectTime; 
            entity.TakeDamage(DOTAmount);
        }
    }
}
