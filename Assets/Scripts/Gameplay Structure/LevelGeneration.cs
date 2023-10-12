using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGeneration : MonoBehaviour
{
    private GoLAutomaton automaton;
    private EnemyPlacement enemyPlacement;
    private int[,] terrain;
    [SerializeField] private Tilemap topMap;
    [SerializeField] private Tilemap baseMap;
    [SerializeField] private Tile obstacleTile;
    private int width;
    private int height;
    private Vector3Int origin;

    // Start is called before the first frame update
    void Start()
    {
        automaton = gameObject.GetComponent<GoLAutomaton>();
        enemyPlacement = gameObject.GetComponent<EnemyPlacement>();
        origin = baseMap.origin;
        width = baseMap.size.x;
        height = baseMap.size.y;
        terrain = automaton.Simulate(width, height);
        enemyPlacement.PlaceEnemies(terrain);
        RenderMap();
    }

    void RenderMap() {
        for (int i = 0; i < width ; i++) {
            for (int j = 0; j < height; j++) {
                // 1 = tile, 0 = no tile
                if (terrain[i, j] == 1)
                {
                    topMap.SetTile(new Vector3Int(i + origin.x, j + origin.y, 0), obstacleTile);
                }
            }
        }
    }
}
