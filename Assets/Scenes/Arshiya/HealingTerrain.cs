using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTerrain : MonoBehaviour
{
    //variable declarations
    [SerializeField] private float healAmount;
    public SpriteRenderer spriteRenderer;
    float minX, minY, maxX, maxY;
    public SpriteRenderer playerRenderer;
    public GameObject player;
    public void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        playerRenderer = player.gameObject.GetComponent<SpriteRenderer>();
        minX = spriteRenderer.bounds.min.x;
        minY = spriteRenderer.bounds.min.y;
        maxX = spriteRenderer.bounds.max.x;
        maxY = spriteRenderer.bounds.max.y; 
    }

    private bool Contains(SpriteRenderer other)
    {
        return minX <= other.bounds.min.x
            && minY <= other.bounds.min.y
            && maxX >= other.bounds.max.x
            && maxY >= other.bounds.max.y;
    }

    public void Update()
    {
        if (Contains(playerRenderer))
        {
            Debug.Log("Player found");
            player.GetComponent<Entity>().Heal(healAmount);

        }
    }
}
