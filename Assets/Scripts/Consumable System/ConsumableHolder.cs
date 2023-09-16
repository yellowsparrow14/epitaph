using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Adds/Removes charges to the consumable
// Updates number of charges on the slot
// Updates image on the slot
public class ConsumableHolder : MonoBehaviour
{
    [Header("Rosary Beads Consumable")]
    private RosaryBeadsConsumable beadsConsumable;
    private Image beadsConsumableImg;

    GameObject parent;

    // [SerializeField] private ConsumableInventoryManager consumableManager;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // update number of charges and image and cooldown
    }

    public void OnConsumable(InputAction.CallbackContext context) 
    {
        // activate consumable, decrease number of charges
        // pass in the player entity to the consumable
        consumable.Activate(parent.GetComponent<Player>);
    }

}   