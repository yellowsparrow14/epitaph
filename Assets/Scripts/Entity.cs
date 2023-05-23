using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private float health;
    private float movementSpeed;
    private float attack;
    // Start is called before the first frame update
    void Start()
    {
        //override in child classes
    }

    // Update is called once per frame
    void Update()
    {
        //override in child classes
    }

    void Die() {
        //override in child classes
    }
}
