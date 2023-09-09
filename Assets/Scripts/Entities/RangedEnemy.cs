using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RangedEnemy : Entity
{
    private float timer = 3f;

    public override void Die() {
        Destroy(gameObject);
    }

    public float movementSpeed {
        get { return movementSpeed; }
    }

    public override void DealDamage(Entity target, float dmgAmt)    
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 2)
        {
            Debug.Log("it work");
            new StopAgentNode(this.gameObject.transform, agent);
            // Add shoot logic with damage to player
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // Spawn Bullet or whatever else
            }
        }
        else
        {
            Debug.Log("why");
            new StopAgentNode(this.gameObject.transform, agent);
        }
    }
}
