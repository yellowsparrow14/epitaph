using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RayCastAbility : Ability
{
    public float rayWidth;
    public float range;
    public float damage;
    public float tickRate;
    public override void Activate(GameObject parent)
    {
        parent.GetComponent<RayCastTrigger>().Fire(rayWidth, range, damage, tickRate);
    }

    public override void Deactivate(GameObject parent) 
    {
        parent.GetComponent<RayCastTrigger>().Stop();
    }

    public override void AbilityHandler(GameObject parent) {
        switch (state) 
        {
            case AbilityState.ready:
                if (abilityPressed) {
                    Activate(parent);
                    state = AbilityState.active;
                    currentActiveTime = activeTime;
                    fillAmount = 1;
                }
            break;
            case AbilityState.active:
                if (currentActiveTime > 0) {
                    currentActiveTime -= Time.deltaTime;
                } else {
                    state = AbilityState.cooldown;
                    currentCooldownTime = cooldownTime;
                    Deactivate(parent);
                }
            break;
            case AbilityState.cooldown:
                if (currentCooldownTime > 0) {
                    currentCooldownTime -= Time.deltaTime;
                    fillAmount -= 1/cooldownTime * Time.deltaTime;
                } else {
                    state = AbilityState.ready;
                }
            break;
        }
    }
}
