using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //UPDATE LATER WITH UNIQUE BEHAVIOR, IF NEEDED
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //UPDATE LATER WITH UNIQUE BEHAVIOR, IF NEEDED
        base.Update();
    }

    protected override void Die() {
        Destroy(gameObject);
    }

    public override void TakeDamage(float dmgAmt) {
        GameObject player = GameObject.FindWithTag("Player");
        base.TakeDamage(dmgAmt);
        //Knockback(player);
    }
}
