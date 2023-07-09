using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileAbility : Ability
{
    
    public override void Activate(GameObject parent)
    {
        GameObject.FindGameObjectWithTag("RotatePoint").GetComponent<ProjectileTrigger>().Fire();
    }

    public override void Deactivate(GameObject parent) 
    {
        GameObject.FindGameObjectWithTag("RotatePoint").GetComponent<ProjectileTrigger>().Stop();
    }

    public override void AbilityHandler(GameObject parent) {
        switch (state) 
        {
            case AbilityState.ready:
                if (abilityPressed) {
                    Activate(parent);
                    state = AbilityState.active;
                    currentActiveTime = activeTime;
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
                } else {
                    state = AbilityState.ready;
                }
            break;
        }
    }
}