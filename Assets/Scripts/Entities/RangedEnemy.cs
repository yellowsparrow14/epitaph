using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
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
        //UPDATE LATER WITH UNIQUE BEHAVfIOR, IF NEEDED
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < 10)
        {
            movementSpeed = 0;
        }
        else
        {
            movementSpeed = 6;
        }
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
