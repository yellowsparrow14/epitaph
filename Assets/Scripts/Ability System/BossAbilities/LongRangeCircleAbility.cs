using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeCircleAbility : BossAbility
{
    [SerializeField]
    public float delay;
    private List<EnemyProjectileScript> projectiles;

    [SerializeField]
    private float aoeRadius = 1;

    [SerializeField]
    private float damage = 5;

    [SerializeField]
    private float maxRounds;

    public override void AbilityBehavior(GameObject parent)
    {
        StartCoroutine(WaitAndCast(parent));
    }

    IEnumerator WaitAndCast(GameObject parent)
    {
        yield return new WaitForSeconds(delay);
        Vector2 center = parent.transform.position;
        for (int i = 0; i < maxRounds; i++)
        {
            ThrowCircle(center, i);
        }
    }

    private void ThrowCircle(Vector2 center, int offset)
    {
        
    }
}
