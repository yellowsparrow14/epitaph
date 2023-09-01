using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    protected bool abilityNotAssigned = true;
    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float cooldownTime = 1f;
    public float activeTime = 1f;
    protected AbilityState state;
    protected bool abilityPressed;
    protected float currentActiveTime;
    protected float currentCooldownTime;
    public float fillAmount;

    public virtual void Activate(GameObject parent) {}
    public virtual void Deactivate(GameObject parent) {}
    public virtual void BeginCooldown(GameObject parent) {}
    public virtual void AbilityHandler(GameObject parent) {}
    public virtual void Init() {}
    public virtual void AbilityBehavior(GameObject parent) {}

    public void SetAbilityPressed(bool pressed) {
        abilityPressed = pressed;
    }

    public void SetState(AbilityState state) {
        this.state = state;
    }

    public Ability GetAbility() {
        return this;
    }

    public bool GetAbilityNotAssigned() {
        return this.abilityNotAssigned;
    }

    public void SetAbilityNotAssigned(bool assigned) {
        this.abilityNotAssigned = assigned;
    }


}

public enum AbilityState {
    ready,
    reactive,
    active,
    cooldown
}


