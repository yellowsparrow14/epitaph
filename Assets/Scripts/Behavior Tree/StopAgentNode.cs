using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTArchitecture;


public class StopAgentNode : Node
{
    // stops the agent and automatically returns success
    private Transform _self;
    private NavMeshAgent _agent;

    public StopAgentNode(Transform self, UnityEngine.AI.NavMeshAgent agent) {
        _self = self;
        _agent = agent;
    }

    public override NodeState Evaluate() {
        _self.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        _agent.isStopped = true;
        return NodeState.SUCCESS;
    }
}
