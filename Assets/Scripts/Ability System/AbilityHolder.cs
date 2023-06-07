using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability1;
    public Ability ability2;
    float lastAbility1Time = 0f;
    float lastAbility2Time = 0f;

    GameObject parent;
    enum AbilityState {
        ready,
        active,
        cooldown
    }

    AbilityState state1 = AbilityState.ready;
    AbilityState state2 = AbilityState.ready;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAbility1(InputAction.CallbackContext context) 
    {
        switch (state1) 
        {
            case AbilityState.ready:
                lastAbility1Time = Time.time;
                ability1.Activate(this.gameObject);
                state1 = AbilityState.active;             
            break;
            case AbilityState.active:
                if (Time.time - lastAbility1Time > ability1.activeTime) {
                    state1 = AbilityState.cooldown;
                }
            break;
            case AbilityState.cooldown:
                if (Time.time - lastAbility1Time > ability1.cooldownTime) {
                    state1 = AbilityState.ready;
                } 
            break;
        }

    }

    public void OnAbility2(InputAction.CallbackContext context) 
    {
        Debug.Log("e");
        switch (state2) 
        {
            case AbilityState.ready:
                lastAbility2Time = Time.time;
                ability2.Activate(this.gameObject);
                state2 = AbilityState.active;
            break;
            case AbilityState.active:
                if (Time.time - lastAbility2Time > ability2.activeTime) {
                    state2 = AbilityState.cooldown;
                }
            break;
            case AbilityState.cooldown:
                if (Time.time - lastAbility2Time > ability2.cooldownTime) {
                    state2 = AbilityState.ready;
                } 
            break;
        }
    }
}
