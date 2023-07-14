using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private float movementSpeed;
    private float attack;
    private Controller ctrl;

    //getters
    public float CurrentHealth {
        get {return currentHealth;}
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //override in child classes
        currentHealth = maxHealth;
        ctrl = this.gameObject.GetComponent<Controller>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //override in child classes
    }

    protected virtual void Die() {
        //override in child classes
        Destroy(this.gameObject);
    }

    protected virtual void TakeDamage(float dmgAmt) {
        //override in child classes
        if (currentHealth - dmgAmt <= 0) {
            this.Die();
        } else {
            currentHealth -= dmgAmt;
        }
    }

}
