using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTArchitecture;

public class FollowPlayer : Node
{
    // Start is called before the first frame update

    private GameObject _target;
    private NavMeshAgent _agent;
    
    public FollowPlayer(GameObject target, UnityEngine.AI.NavMeshAgent agent, float speed) {
        _target = target;
        _agent = agent;
        _agent.updateRotation = false;
        _agent.speed = speed;
        _agent.updateUpAxis = false;
    }

    public override NodeState Evaluate() {
        _agent.SetDestination(_target.transform.position);
        return NodeState.SUCCESS;
    }
}
