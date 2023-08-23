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

        agent.updateRotation = false;
        agent.speed = speed;
        agent.updateUpAxis = false;

        Node root = new SelectorNode(new List<Node>{
            new SequenceNode(new List<Node>{
                new DetectPlayerNode(this.gameObject),
                new StopAgentNode(this.gameObject.transform, agent),
            }),
            new FollowPlayerNode(target, agent, speed),
        });
        
        //Node root = new FollowPlayerNode(target, agent, speed);
        
        return root;
    }
}
