using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceQCooldownAugment : StaticAugment
{

    private Entity recipient;

    private SlotClass targetSlot;

    private float originalCooldown;

    [SerializeField]
    private float cooldownReduction = 0.4f;

    public void applyAugment(Entity entity) {
        recipient = entity;
        targetSlot = entity.transform.gameObject.GetComponent<AbilityInventoryManager>().HotBarAbilities[1];
        if (targetSlot.isClear()) return;

        originalCooldown = targetSlot.GetAbility().getActiveAbility().cooldownTime;
        targetSlot.GetAbility().getActiveAbility().cooldownTime = originalCooldown * (1 - cooldownReduction);
    }

    public void removeAugment() {
        targetSlot.GetAbility().getActiveAbility().cooldownTime = originalCooldown;
    }

}
