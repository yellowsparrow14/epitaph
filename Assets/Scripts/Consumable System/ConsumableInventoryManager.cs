// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ConsumableInventoryManager : MonoBehaviour
// {
//     [SerializeField] private GameObject hotbarSlotHolder;
//     [SerializeField] private Consumable[] startingConsumables;

//     private ConsumableSlot[] hotbarConsumables;
//     private GameObject[] hotbarSlots;

//     // Start is called before the first frame update
//     private void Start()
//     {
//         hotbarSlots = new GameObject[hotbarSlotHolder.transform.childCount];
//         hotbarConsumables = new ConsumableSlot[hotbarSlots.Length];

//         for (int i = 0; i < hotbarSlots.Length; i++) {
//             hotbarSlots[i] = hotbarSlotHolder.transform.GetChild(i).gameObject;
//         }

//         for (int i = 0; i < hotbarConsumables.Length; i++) {
//             hotbarConsumables[i] = new ConsumableSlot();
//         }

//         // for testing
//         hotbarConsumables[0].AddConsumable(startingConsumables[0]);

//         RefreshHotBar();
//     }

//     // Update is called once per frame
//     private void Update() {

//     }

//     #region Consumable Inventory Utils

//     // refresh sprites of consumables
//     public void RefreshHotBar() 
//     {
        
//     }

//     // add a consumable to the hotbar
//     public bool Add(Consumable consumable)
//     {
//         return false;
//     }

//     // remove a consumable from the hotbar
//     public bool Remove(Consumable consumable)
//     {
//         return false;
//     }

//     // return the slot class that matches the consumable given
//     public ConsumableSlot Contains(Consumable consumable) 
//     {
//         return null;
//     }

//     #endregion Inventory Utils

//     public ConsumableSlot[] GetHotbarConsumables() {
//         return hotbarConsumables;
//     }

//     public GameObject[] GetHotbarSlots() {
//         return hotbarSlots;
//     }
// }
