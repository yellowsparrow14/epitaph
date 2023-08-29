using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    [Header("Ability 1")]
    public Ability ability1;
    public Image ability1Img;
    
    [Header("Ability 2")]
    public Ability ability2;
    public Image ability2Img;

    [Header("Ability 3")]
    public Ability ability3;
    public Image ability3Img;

    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        ability1Img.sprite = ability1.aSprite;
        ability2Img.sprite = ability2.aSprite;
        ability3Img.sprite = ability3.aSprite;


        ability1Img.fillAmount = 0;
        ability2Img.fillAmount = 0;
        ability3Img.fillAmount = 0;
        ability1.SetState(AbilityState.ready);
        ability2.SetState(AbilityState.ready);
        ability3.SetState(AbilityState.ready);
        parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {  
        ability1.AbilityHandler(parent);
        ability2.AbilityHandler(parent);
        ability3.AbilityHandler(parent);

        ability1Img.fillAmount = ability1.fillAmount;
        ability2Img.fillAmount = ability2.fillAmount;
        ability3Img.fillAmount = ability3.fillAmount;

    }

    public void OnAbility1(InputAction.CallbackContext context) 
    {
        if (context.started)
        {   
            ability1.SetAbilityPressed(true);
        }
        else if (context.canceled)
        {
            ability1.SetAbilityPressed(false);
        }
    }

    public void OnAbility2(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            ability2.SetAbilityPressed(true);

        }
        else if (context.canceled)
        {
            ability2.SetAbilityPressed(false);
        }
    }

    public void OnAbility3(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            ability3.SetAbilityPressed(true);
        }
        else if (context.canceled)
        {
            ability3.SetAbilityPressed(false);
        }
    }

}   