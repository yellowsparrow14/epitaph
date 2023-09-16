using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedGoonController : EnemyController
{

    public GameObject spawningEnemy;

    public float shortestSpawnTime;

    public float longestSpawnTime;

    private float timer;
    void Start(){
        agent.velocity = Vector2.zero;
        randomTime = 
    }
    void Update(){
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject target = GameObject.FindWithTag("Player");
        timer += Time.deltaTime;
        if (timer > unloadSpeed)
        {
            // Spawn Bullet or whatever else
            timer = 0;
            Spawn();
            randomTime = 
            }
        }
    void Spawn(){
        //logic to spawn
    }    
}
