using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : ScriptableObject
{
    public string cName = "New Consumable";
    public Sprite aSprite;
    public AudioClip aSound;
    public float activeTime = 1f;
    public virtual void Activate(GameObject parent) {}
    public virtual void Init() {}
    // Handles what an ability does
    public virtual void ConsumableBehavior(GameObject parent) {}

    public Consumable GetConsumable() {
        return this;
    }
}


