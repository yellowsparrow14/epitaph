using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPlacement : MonoBehaviour
{
    public List<EnemyPlacementType> registeredEnemyTypes = new List<EnemyPlacementType>();
    private int mapWidth;
    private int mapHeight;
    private int[,] map;
    private float rampingPercent;
    [SerializeField] private float rampFactor;
    [SerializeField] private Tilemap baseMap;
    private Vector3Int origin;
    public void PlaceEnemies(int[,] occupiedMap) {
        map = occupiedMap.Clone() as int[,];
        mapWidth = occupiedMap.GetLength(1);
        mapHeight = occupiedMap.GetLength(0);
        origin = baseMap.origin;

        foreach (EnemyPlacementType enemy in registeredEnemyTypes) {
            PlaceEnemy(enemy);
        }
    }

    void PlaceEnemy(EnemyPlacementType enemy) {
        rampingPercent = enemy.spawnRate;
        for (int i = 0; i < mapWidth; i++) {
            for (int j = 0; j < mapHeight; j++) {
                if (CheckNeighborsClear(i, j, enemy.width, enemy.height)) { 
                    if (Random.Range(1, 101) < rampingPercent) {
                        Vector3Int tileLoc = new Vector3Int(origin.x + i, origin.y + j, 0);
                        Vector3 spawnTilePos = baseMap.CellToWorld(tileLoc);
                        Instantiate(enemy.enemy, new Vector3(spawnTilePos.x+0.5f*enemy.width, spawnTilePos.y+0.5f*enemy.height, 0), Quaternion.identity);
                        OccupyNeighbors(i, j, enemy.width, enemy.height);
                        rampingPercent = enemy.spawnRate;
                    } else {
                        rampingPercent *= rampFactor;
                    }
                }
            }
        }
    }
    private void OccupyNeighbors(int x, int y, int width, int height) {
        BoundsInt bounds = new BoundsInt(x, y, 0, width, height, 1);
        foreach (var b in bounds.allPositionsWithin) {
            if (b.x >= 0 && b.x < mapWidth && b.y >= 0 & b.y < mapHeight) {
                map[b.x, b.y] = 1;
            }
        }
    }
    private bool CheckNeighborsClear(int x, int y, int width, int height) {
        BoundsInt bounds = new BoundsInt(x, y, 0, width, height, 1);
        foreach (var b in bounds.allPositionsWithin) {
            if (b.x >= 0 && b.x < mapWidth && b.y >= 0 & b.y < mapHeight) {
                if (map[b.x, b.y] == 1) {
                    return false;
                }
            }
        }
        return true;
    }
}