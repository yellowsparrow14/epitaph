using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsumableSlot
{
    [SerializeField] private Consumable consumable;
    
    public ConsumableSlot() {
        consumable = null;
    }

    public ConsumableSlot (Consumable consumable) {
        this.consumable = consumable;
    }

    public ConsumableSlot (ConsumableSlot consumableSlot) {
        this.consumable = consumableSlot.GetConsumable();
    }

    public Consumable GetConsumable() {
        return consumable;
    }
    
    public void AddConsumable(Consumable consumable) {
        this.consumable = consumable;
    }

    public void Clear() {
        this.consumable = null;
    }
}
