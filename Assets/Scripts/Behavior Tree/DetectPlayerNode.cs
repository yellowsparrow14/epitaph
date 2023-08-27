using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTArchitecture;

public class DetectPlayerNode : Node
{
    // detects if the enemy is colliding with the player

    private EnemyController _enemy;
    
    public DetectPlayerNode(GameObject enemy) {
        _enemy = enemy.GetComponent<EnemyController>();
    }

    public override NodeState Evaluate() {
        if (_enemy.IsColliding) {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
