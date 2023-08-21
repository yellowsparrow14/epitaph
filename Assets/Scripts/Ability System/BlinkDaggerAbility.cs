using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlinkDaggerAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        GameObject.FindGameObjectWithTag("RotatePoint").GetComponent<BlinkDaggerTrigger>().Fire(parent);
        Debug.Log("bye");
    }

    public override void Deactivate(GameObject parent) 
    {
        GameObject.FindGameObjectWithTag("RotatePoint").GetComponent<BlinkDaggerTrigger>().Stop();
    }

    public override void AbilityHandler(GameObject parent) {
        Debug.Log("abilityhandler");
        switch (state) 
        {
            case AbilityState.ready:
                if (abilityPressed) {
                    Activate(parent);
                    Deactivate(parent);

                    state = AbilityState.reactive;
                    fillAmount = 1;
                }
            break;
            case AbilityState.reactive:
                if (abilityPressed) {
                    Activate(parent);
                    Deactivate(parent);

                    state = AbilityState.active;
                }
            break;
            case AbilityState.active:
                if (GameObject.FindGameObjectWithTag("RotatePoint").GetComponent<BlinkDaggerTrigger>().teleported == true) {
                    state = AbilityState.cooldown;
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
