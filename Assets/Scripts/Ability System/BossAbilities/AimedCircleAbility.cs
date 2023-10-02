using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedCircleAbility : BossAbility
{
    [SerializeField]
    public float delay;
    public GameObject indicator;
    public BossProjectile projectile;

    [SerializeField]
    private float damage = 5;

    [SerializeField]
    private float projectileSpeed;

    public override void AbilityBehavior(GameObject parent)
    {
        StartCoroutine(WaitAndCast(parent));
    }

    IEnumerator WaitAndCast(GameObject parent)
    {
        // Create Indicator for where the projectile will go
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 aimedLocation = player.transform.position;
        Instantiate(indicator, aimedLocation, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        //Shoot projectile
        Vector3 direction = this.transform.position - aimedLocation;
        BossProjectile proj = Instantiate(projectile, this.transform.position + (direction.normalized * 2), Quaternion.identity);
        proj.GetRB().velocity = direction.normalized * projectileSpeed;

        Destroy(this.gameObject);
    }

}
