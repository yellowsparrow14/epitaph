using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SlowingTerrain : MonoBehaviour
{
    //variable declarations
    [SerializeField] private bool setByPlayer;
    private bool isPlayer;

    [SerializeField]
    public float baseMoveSpeedMultiplier = 0.3f;
    private float moveSpeedMultiplier;
    private SpeedDecrease modifier;

    //called once an entity enters the slowing pool
    public void Init() {
        moveSpeedMultiplier = baseMoveSpeedMultiplier;
        modifier = new SpeedDecrease(moveSpeedMultiplier);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //determine if the Entity is a Player by seeing if it has the Player script
        Debug.Log("New Entity being slowed");
        ModifiableStat speed = collision.gameObject.GetComponent<Player>().EntityStats.GetStat(StatEnum.WALKSPEED);
        //ModifiableStat speed = collision.gameObject.GetComponent<Entity>().GetStat(StatEnum.WALKSPEED);
        speed.AddModifier(modifier);
        
        //if it is and the source is player OR if it isn't and the source is enemy
        // if((isPlayer && setByPlayer) || (!isPlayer && !setByPlayer))
        // {
        //     //add the Entity to the list of entities currently in the pool
        //     entitiesBeingSlowed.Add(collision.gameObject);
        //     Debug.Log("Length of list: " + entitiesBeingSlowed.Count);
        //     //slow the entity while its in the pool
        //     InvokeRepeating("Slow", 0f, timeInterval);

        // }
        // //otherwise, do nothing
        // else
        // {
        //     Debug.Log("Wrong Entity!");
        // }
        
    }

    //called when an entity leaves the pool
    void OnTriggerExit2D(Collider2D collision)
    {
        //ModifiableStat speed = collision.gameObject.entity.EntityStats.GetStat(StatEnum.WALKSPEED);
        ModifiableStat speed = collision.gameObject.GetComponent<Player>().EntityStats.GetStat(StatEnum.WALKSPEED);
        speed.RemoveModifier(modifier);
        Debug.Log("Entity no longer being slowed");
        //remove the entity from the list of entities in the pool
        // entitiesBeingSlowed.Remove(collision.gameObject);
        // Debug.Log("Length of list: " + entitiesBeingSlowed.Count);
        // //if there are no entities
        // if(entitiesBeingSlowed.Count == 0) 
        // {
        //     //stop running the foreach loop
        //     CancelInvoke();
        // }
    }

    //called from an external script when a Player or enemy places down a slowing pool
    //takes in boolean parameter that would be true if this method was called by a Player ability and false otherwise
    public void SetSource(bool wasPlayer)
    {
        setByPlayer = wasPlayer;
    }
   
}
