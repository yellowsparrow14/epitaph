using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantHealPot : Consumable
{
    public string cName = "New Consumable";
    [SerializeField] public int healAmount;
    public override void Activate(GameObject parent) {
        // increase player's health by heal amount
        Debug.Log("heal pot activated")
    }

    // Handles what an ability does
    public override void ConsumableBehavior(GameObject parent) {}

}


