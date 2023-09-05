using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour //IEffectable
{
    private EntityStats _entityStats;
    public EntityStats EntityStats => _entityStats;
    private Health _health;
    public Health Health => _health;


    [SerializeField] private float knockbackDelay;
    [SerializeField] private float knockbackForce;

    private float currentHealth;
    private float movementSpeed;
    private Rigidbody2D body;

    [SerializeField] private float attack;

    public float Attack {
        get { return attack; }
        set { attack = value; }
    }

    protected virtual void Start()
    {
        //override in child classes
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public virtual void Die() {
        //override in child classes
        Debug.Log("dead");
    }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }
    
    public virtual void DealDamage(Entity target, float dmgAmt) {
        target.TakeDamage(dmgAmt);
    }
    
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
