using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float cooldownTime = 1f;
    public float activeTime = 1f;
    public AbilityState state;
    public bool abilityPressed;
    public float currentActiveTime;
    public float currentCooldownTime;
    public float fillAmount;

    public virtual void Activate(GameObject parent) {}
    public virtual void Deactivate(GameObject parent) {}
    public virtual void BeginCooldown(GameObject parent) {}
    public virtual void AbilityHandler(GameObject parent) {}

    public void SetAbilityPressed(bool pressed) {
        abilityPressed = pressed;
    }

    public void SetState(AbilityState state) {
        this.state = state;
    }
}

public enum AbilityState {
    ready,
    active,
    cooldown
}


