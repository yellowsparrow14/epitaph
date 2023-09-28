using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichController : Controller
{
    [SerializeField]
    int activeCrystals;
    bool hasShield;
    // Start is called before the first frame update
    void Start()
    {
        hasShield = true;
        activeCrystals = 3;
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
}
