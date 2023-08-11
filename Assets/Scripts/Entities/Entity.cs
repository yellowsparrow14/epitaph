using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEffectable
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private float movementSpeed;
    private Rigidbody2D body;

    private float attack;
    private Controller ctrl;
    private StatusEffect _data;

    //getters
    public float CurrentHealth {
        get {return currentHealth;}
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //override in child classes
        body = this.gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        ctrl = this.gameObject.GetComponent<Controller>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_data != null) {
            _data.HandleEffect(this);
        }
        //override in child classes
    }

    protected virtual void Die() {
        //override in child classes
        Debug.Log("dead");
    }

    public virtual void TakeDamage(float dmgAmt) {
        //override in child classes
        if (currentHealth - dmgAmt <= 0) {
            this.Die();
        } else {
            currentHealth -= dmgAmt;
        }
    }

    // move this stuff also to status effect

    public void ApplyEffect(StatusEffect _data)
    {
        this._data = _data;
        //Debug.Log(_data.name);
        _data.currentEffectTime = 0f;
        _data.lastTickTime = 0f;
    }

    public void RemoveEffect()
    {
        _data = null;
    }

    // move to status effect
}
