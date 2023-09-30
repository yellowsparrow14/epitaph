using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LichController : Controller
{
    public List<BossAbility> abilities;
    public List<BossAbility> defensiveAbilities;

    [SerializeField]
    int activeCrystals;
    bool hasShield;

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

    public void ChooseAttack()
    {
        if (activeCrystals > 0)
        {
            // Phase 1 stuff
            
        } else
        {
            // Phase 2 stuff
            print("Crystals destroyed!, Phase 2 incomplete");
        }
    }

    public void ChooseDefensive()
    {
        BossAbility choice = defensiveAbilities[0];
        choice.AbilityBehavior(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChooseDefensive();
        }
    }
}
