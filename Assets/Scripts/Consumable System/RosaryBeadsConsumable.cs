using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// set up this class such that the activate function will activate any "ConsumableEffects" which will be from other classes
// that derive from a base effect class. The base effect class is not the same as the default heal effect. Then when you activate
// the consumable, you will loop through the effects and activate each of them in turn
public class RosaryBeadsConsumable : ScriptableObject
{
    [SerializeField]
    public string cName = "Rosary Beads";
    [SerializeField]
    public Sprite aSprite;
    [SerializeField]
    public AudioClip aSound;
    [SerializeField]
    public float activeTime = 1f;
    protected bool consumablePressed;
    protected CooldownState state;
    public virtual void Init() {

    }
    // Activate the heal over time effect of the rosary beads, and any additional effects
    public virtual void Activate(Entity player) {

    }
    // Handles what an ability does
    public virtual void ConsumableBehavior(GameObject parent) {

    }

    public RosaryBeadsConsumable GetConsumable() {
        return this;
    }

    public virtual void Activate(GameObject parent) {}
    public virtual void Deactivate(GameObject parent) {}
    // Handles ability cooldown system
    public virtual void ConsumableCooldownHandler(GameObject parent) {}

    public void SetConsumablePressed(bool pressed) {
        consumablePressed = pressed;
    }

    public void SetState(CooldownState state) {
        this.state = state;
    }
}
public enum CooldownState {
    ready,
    active,
    cooldown
}

