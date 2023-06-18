using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float health;
    private float movementSpeed;
    private float attack;
    private Controller ctrl;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //override in child classes
        ctrl = this.gameObject.GetComponent<Controller>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //override in child classes
    }

    protected virtual void Die() {
        Destroy(this.gameObject);
    }

    protected virtual void TakeDamage(float dmgAmt) {
    }
}
