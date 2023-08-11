using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTArchitecture;

public class GoonBT : BehaviorTree
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    protected override Node SetupTree() {
        GameObject target = GameObject.FindWithTag("Player");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Node root = new FollowPlayer(target, agent, speed);
        return root;
    }
}
