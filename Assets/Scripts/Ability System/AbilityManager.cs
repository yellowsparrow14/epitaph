using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private Ability newAbility;
    [SerializeField] private Ability abilityToDiscard;

    private GameObject[] slots;

    public List<SlotClass> abilities = new List<SlotClass>();
    // Start is called before the first frame update
    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];

        for (int i = 0; i < slotHolder.transform.childCount; i++) {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();    
        Add(newAbility);
        Remove(abilityToDiscard);
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++) {
            try {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = abilities[i].GetAbility().aSprite;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
            } catch {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    public void Add(Ability ability)
    {
        //abilities.Add(ability);
        RefreshUI();
    }

    public void Remove(Ability ability)
    {
        //abilities.Remove(ability); 
        RefreshUI();
    }


}
