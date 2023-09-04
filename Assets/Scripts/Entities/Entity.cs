using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour //IEffectable
{
    public EntityStats entityStats;

    [SerializeField] private float maxHealth;
    [SerializeField] private float knockbackDelay;
    [SerializeField] private float knockbackForce;

    private float currentHealth;
    private float movementSpeed;
    private Rigidbody2D body;

    [SerializeField] private float attack;
   // private StatusEffect[] _statusEffects;

    //getters
    public float CurrentHealth {
        get {return currentHealth;}
    }

    public float Attack {
        get { return attack; }
        set { attack = value; }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //override in child classes
        body = this.gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       // if (_data != null) {
        //    _data.HandleEffect(this);
       // }
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
    
    public virtual void DealDamage(Entity target, float dmgAmt) {
        target.TakeDamage(dmgAmt);
    }

  /*  public void ApplyEffect(StatusEffect _data)
    {
        this._data = _data;
        //Debug.Log(_data.name);
        _data.currentEffectTime = 0f;
        _data.lastTickTime = 0f;
    }

    public void RemoveEffect()
    {
        _data = null;
    }*/

    public void Knockback(GameObject applier) {
        Debug.Log("KNOCK");
        StopAllCoroutines();
        Vector2 direction = (transform.position - applier.transform.position).normalized;
        body.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(ResetKnockBack());
    }

    private IEnumerator ResetKnockBack() {
        yield return new WaitForSeconds(knockbackDelay);
        body.velocity = Vector3.zero;
    }

}
