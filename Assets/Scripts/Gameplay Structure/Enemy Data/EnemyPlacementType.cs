using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPlacementType
{
    public  GameObject enemy;
    [Range(0, 100)] [SerializeField] public int spawnRate;

    public int width;
    public int height;
}