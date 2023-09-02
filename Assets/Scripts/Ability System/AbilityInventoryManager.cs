using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject abilityCursor;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject hotbarSlotHolder;

    [SerializeField] private Ability newAbility;
    [SerializeField] private Ability abilityToDiscard;


    //public List<Ability> abilities11 = new List<Ability>();

    [SerializeField] private SlotClass[] startingAbilities;
    private SlotClass[] abilities;
    private SlotClass[] hotbarAbilities;

    private GameObject[] slots;
    private GameObject[] hotbarSlots;


    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    bool isMovingItem;

    // Start is called before the first frame update
    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        abilities = new SlotClass[slots.Length];

        hotbarSlots = new GameObject[hotbarSlotHolder.transform.childCount];
        hotbarAbilities = new SlotClass[hotbarSlots.Length];

        for (int i = 0; i < hotbarSlots.Length; i++) {
            hotbarSlots[i] = hotbarSlotHolder.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < abilities.Length; i++) {
            abilities[i] = new SlotClass();
        }

        for (int i = 0; i < hotbarAbilities.Length; i++) {
            hotbarAbilities[i] = new SlotClass();
        }

        for (int i = 0; i < startingAbilities.Length; i++) {
            abilities[i] = startingAbilities[i];
        }

        for (int i = 0; i < slotHolder.transform.childCount; i++) {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();    
        Add(newAbility);
        Remove(abilityToDiscard);
    }

    private void Update() {
        abilityCursor.SetActive(isMovingItem);
        abilityCursor.transform.position = Input.mousePosition; 
        if (isMovingItem) {
            abilityCursor.GetComponent<Image>().sprite = movingSlot.GetAbility().aSprite;
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            if (isMovingItem) {
                EndItemMove();
            } else {
                BeginItemMove();
            }
        }
    }


    #region Inventory Utils

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++) {
            try {
                //slots[i].transform.GetChild(0).GetComponent<Image>().sprite = abilities[i].GetAbility().aSprite;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = abilities[i].GetAbility().aSprite;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
            } catch {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }

        RefreshHotBar();
    }

    public void RefreshHotBar() 
    {
        for (int i = 0; i < hotbarSlots.Length; i++) {
            try {
                //slots[i].transform.GetChild(0).GetComponent<Image>().sprite = abilities[i].GetAbility().aSprite;
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = abilities[i + hotbarSlots.Length * 2].GetAbility().aSprite;
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                hotbarAbilities[i] = abilities[i + hotbarSlots.Length * 2];

                if (hotbarAbilities[i].GetAbility() != null) {
                    hotbarAbilities[i].GetAbility().Init();
                    hotbarAbilities[i].GetAbility().SetState(AbilityState.ready);
                    hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().fillAmount = 0;
                }

            } catch {
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }        
    }

    // Update is called once per frame
    public bool Add(Ability ability)
    {
        //abilities.Add(ability);
        SlotClass slot = Contains(ability);
        if (slot != null) {

        } else {
            for (int i = 0; i < abilities.Length; i++) {
                if (abilities[i].GetAbility() == null) {
                    abilities[i].AddAbility(ability);
                    break;
                }
            }    
        }
        
        RefreshUI();
        return true;
    }

    public bool Remove(Ability ability)
    {
        //abilities.Remove(ability); 
        SlotClass temp = Contains(ability);
        if (temp != null) {
            int slotToRemoveIndex = 0;

            for (int i = 0; i < abilities.Length; i++) {
                if (abilities[i].GetAbility() == ability) {
                    slotToRemoveIndex = i;
                    break;
                }
            }
            abilities[slotToRemoveIndex].Clear();
        } else {
            return false;
        }

        RefreshUI();
        return true;

    }

    public SlotClass Contains(Ability ability) 
    {
        for (int i = 0; i < abilities.Length; i++) {
            if (abilities[i].GetAbility() == ability) {
                return abilities[i];
            }
        }

        return null;
    }

    #endregion Inventory Utils

    #region Drag And Drop
    private SlotClass GetClosestSlot() {
        for (int i = 0; i < slots.Length; i++) {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32) {
                return abilities[i];
            }
        }
        return null;
    }

    private bool BeginItemMove() {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.GetAbility() == null) {
            return false;
        } 
        movingSlot = new SlotClass(originalSlot); 
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove() {
        originalSlot = GetClosestSlot();
        if (originalSlot == null) {
            Add(movingSlot.GetAbility());
            movingSlot.Clear();
        } else {
            if (originalSlot.GetAbility() != null) {
                if (originalSlot.GetAbility() == movingSlot.GetAbility()) {

                } else {
                    tempSlot = new SlotClass(originalSlot);
                    originalSlot.AddAbility(movingSlot.GetAbility());
                    movingSlot.AddAbility(tempSlot.GetAbility());
                    RefreshUI();
                    return true; 
                }
            } else {
                originalSlot.AddAbility(movingSlot.GetAbility());
                movingSlot.Clear();
            }
        }


        isMovingItem = false;
        RefreshUI();
        return true;
    }
    #endregion Drag And Drop

    public SlotClass[] GetHotbarAbilities() {
        return hotbarAbilities;
    }

    public GameObject[] GetHotbarSlots() {
        return hotbarSlots;
    }
}
