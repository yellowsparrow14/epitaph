using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDaggerProjectile : Projectile
{   
    public float acceleration;

    // Update is called once per frame
    void Update()
    {
        if (force > 0) {
            force += acceleration;
        }
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
}
