using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    bool damaged = false;
    float lastDamaged;
    // Start is called before the first frame update
    protected override void Start()
    {
        lastDamaged = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastDamaged > 2)
        {
            damaged = false;
        }
    }
    public override void TakeDamage(float amount)
    {
        Health.TakeDamage(amount);
        damaged = true;
    }

    public bool WasDamaged()
    {
        return damaged;
    }
}
