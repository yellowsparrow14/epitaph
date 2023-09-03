using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LifeStealAugment : Augment
{
    [SerializeField]
    private float stealFactor = 1f; // assuming that you gain health by a factor of the damage you deal

    public override void stackAugments()
    {
        return;
    }

    public override void firstActivation()
    {
        Debug.Log("LifeSteal activated.");
    }
}
