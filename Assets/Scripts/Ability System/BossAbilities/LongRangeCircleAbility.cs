using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeCircleAbility : BossAbility
{
    [SerializeField]
    public float delay;
    public BossProjectile projectile;
    private List<BossProjectile> createdProjectiles;

    [SerializeField]
    private float damage = 5;

    [SerializeField]
    private float maxRounds;

    public override void AbilityBehavior(GameObject parent)
    {
        createdProjectiles = new List<BossProjectile>();
        StartCoroutine(WaitAndCast(parent));
    }

    IEnumerator WaitAndCast(GameObject parent)
    {
        Vector2 center = parent.transform.position;
        for (int i = 0; i < maxRounds; i++)
        {
            CreateCircle(center, i);
            yield return new WaitForSeconds(0.5f);
            ThrowCircle(i);
        }

        Destroy(this.gameObject);
    }

    private void CreateCircle(Vector2 center, int offset)
    {
        for (int i = 0; i < 8; i++)
        {
            float angle = ((45 + (22.5f * offset)) * i) / 180 * Mathf.PI;
            float offsetX = Mathf.Cos(angle) * 2;
            float offsetY = Mathf.Sin(angle) * 2;
            Vector2 directionOut = new Vector2(center.x + offsetX, center.y + offsetY);
            BossProjectile proj = Instantiate(projectile, directionOut, Quaternion.identity);
            createdProjectiles.Add(proj);
        }
    }

    private void ThrowCircle(int offset)
    {
        for (int i = createdProjectiles.Count - 1; i >= 0; i--)
        {
            BossProjectile proj = createdProjectiles[i];
            float angle = ((45 + (22.5f * offset)) * i) / 180 * Mathf.PI;
            float offsetX = Mathf.Cos(angle);
            float offsetY = Mathf.Sin(angle);
            proj.GetRB().velocity = new Vector2(Mathf.Cos(offsetX), Mathf.Sin(offsetY)).normalized * 2;
        }
    }
}
