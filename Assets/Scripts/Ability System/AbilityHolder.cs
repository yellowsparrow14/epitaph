using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability1;
    public Ability ability2;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        ability1.SetState(AbilityState.ready);
        ability2.SetState(AbilityState.ready);
        parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {  
        ability1.AbilityHandler(parent);
        ability2.AbilityHandler(parent);
    }

    public void OnAbility1(InputAction.CallbackContext context) 
    {
        if (context.started)
        {   
            ability1.SetAbilityPressed(true);
            Debug.Log("hi");
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


}
