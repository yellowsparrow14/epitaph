using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        Debug.Log("dash");
        parent.GetComponent<Rigidbody2D>().velocity = parent.GetComponent<Rigidbody2D>().velocity * dashVelocity;
    }
}
