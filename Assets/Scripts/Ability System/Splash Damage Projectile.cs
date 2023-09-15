using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamageProjectile : Projectile
{
    [SerializeField] private float radius;
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D[] Hit = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, LayerMask.GetMask("Enemy"));
        foreach (Collider2D collider in Hit) {
            Enemy enemy = collider.GetComponent<Enemy>();
            parent.GetComponent<Entity>().DealDamage(enemy, damage);
        }
        Destroy(this.gameObject);
    }
}
