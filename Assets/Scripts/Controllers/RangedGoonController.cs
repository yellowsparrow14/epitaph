using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedGoonController : EnemyController
{

    public GameObject projectile;
    public Transform projectilePos;
    private float timer;

    public float distanceAway;

    public float unloadSpeed;
    
    void Update(){
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject target = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < distanceAway)
        {
            agent.velocity = Vector2.zero;
            // Add shoot logic with damage to player
            timer += Time.deltaTime;
            if (timer > unloadSpeed)
            {
                // Spawn Bullet or whatever else
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot(){
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }
}
