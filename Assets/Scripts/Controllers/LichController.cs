using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichController : Controller
{
    // make it easier to pass in the teleportation points
    public GameObject teleportationPoints;
    //currently visible for debugging purposes
    [SerializeField]
    int activeCrystals;
    bool hasShield;
    List<Vector2> tppoints = new List<Vector2>();
    int currentPoint = 0;

    void Start()
    {
        hasShield = true;
        activeCrystals = 3;

        tppoints.Add(this.transform.position);
        foreach (Transform child in teleportationPoints.transform)
        {
            tppoints.Add(child.position);
        }
    }

    public void RemoveCrystal()
    {
        activeCrystals--;
        if (activeCrystals == 0)
        {
            this.RemoveShield();
        }
    }

    private void RemoveShield()
    {
        hasShield = false;
    }

    public bool HasShield()
    {
        return hasShield;
    }

    public void TeleportAwayFromPlayer()
    {
        currentPoint = (currentPoint + 1) % tppoints.Count;
        this.transform.position = tppoints[currentPoint];
    }

    public void SpawnEnemies(Vector2 location)
    {

    }

    public void ShortRangeCircleBlast()
    {

    }

    public void LongRangeShoot()
    {

    }

    public void Meteor()
    {

    }

    //For testing individual spells
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TeleportAwayFromPlayer();
        }
    }
}
