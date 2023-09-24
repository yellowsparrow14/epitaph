using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelfHeal : Ability
{
    public float healRate;

    public override void AbilityBehavior(GameObject parent)
    {
        if (abilityPressed && (parent.GetComponent<Player>().HealthVal <= parent.GetComponent<Player>().Health.intialValue) && (currentCooldownTime <= 0) && 
            (state == AbilityState.active))
        {
            float currentHealthVal = parent.GetComponent<Player>().HealthVal;
            if (currentHealthVal + healRate <= parent.GetComponent<Player>().Health.intialValue)
            {
                parent.GetComponent<Player>().Health.Heal(healRate);
            }
            else
            {  
                float tempHealRate = parent.GetComponent<Player>().Health.intialValue - currentHealthVal;
                parent.GetComponent<Player>().Health.Heal(tempHealRate);
            }
        }
    }

    public override void AbilityCooldownHandler(GameObject parent)
    {
        switch(state)
        {
            case AbilityState.ready:
                currentCooldownTime = 0;
                if(abilityPressed && parent.GetComponent<Player>().HealthVal != parent.GetComponent<Player>().Health.intialValue)
                {
                    state = AbilityState.active;
                    fillAmount = 1;
                }
                break;
            case AbilityState.active:
                state = AbilityState.cooldown;
                currentCooldownTime = cooldownTime;
                break;
            case AbilityState.cooldown:
                if(currentCooldownTime > 0)
                {

                    currentCooldownTime -= Time.deltaTime;
                    fillAmount -= 1 / cooldownTime * Time.deltaTime;
                } 
                else
                {
                    state = AbilityState.ready;
                    fillAmount = 1;
                }
                break;

        }
    }



}
