using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class ConsumableHolder : MonoBehaviour
{
    [Header("Consumable 1")]
    private Consumable consumable1;
    private Image consumable1Img;
    
    [Header("Consumable 2")]
    private Consumable consumable2;
    private Image consumable2Img;

    [Header("Consumablee 3")]
    private Consumable consumable3;
    private Image consumable3Img;

    GameObject parent;

    // [SerializeField] private GameObject abilitySelection;
    [SerializeField] private ConsumableInventoryManager consumableManager;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {  
        
    }

    public void OnConsumable1(InputAction.CallbackContext context) 
    {
        // activate consumable, remove the consumable from the hotbar
    }

    public void OnConsumable2(InputAction.CallbackContext context) 
    {
        // activate consumable, remove the consumable from the hotbar
    }

    public void OnConsumable3(InputAction.CallbackContext context) 
    {
        // activate consumable, remove the consumable from the hotbar
    }

}   