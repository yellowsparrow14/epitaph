using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelection : MonoBehaviour
{
    [SerializeField] private AbilityWrapper[] abilityChoices;
    [SerializeField] private AbilityInventoryManager abilityManager;

    [SerializeField] private Button choice1;
    [SerializeField] private Button choice2;
    [SerializeField] private Button choice3;
    private AbilityWrapper[] options = new AbilityWrapper[3];

    void Awake()
    {
        choice1 = GameObject.Find("Choice1");
        choice2 = GameObject.Find("Choice1");
        choice3 = GameObject.Find("Choice1");

        if (choice1 != null) {
            for (int i = 0; i < 3; i++) {
                int randomIndex = Random.Range(0, abilityChoices.Length);
                options[i] = abilityChoices[randomIndex];
                abilityChoices.RemoveAt(randomIndex);
            }

            choice1.image.sprite = options[0].getActiveAbility().aSprite;
            choice2.image.sprite = options[1].getActiveAbility().aSprite;
            choice3.image.sprite = options[2].getActiveAbility().aSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Choice1() {
        abilityManager.Add(options[0]);
    }

    void Choice2() {
        abilityManager.Add(options[1]);
    }

    void Choice3() {
        abilityManager.Add(options[2]);
    }
}
