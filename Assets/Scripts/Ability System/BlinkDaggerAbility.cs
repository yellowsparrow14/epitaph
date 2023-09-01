using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlinkDaggerAbility : Ability
{
    private Camera mainCam;
    private Vector3 mousePos;
    private bool firing;
    public GameObject dagger;
    private bool canFire;
    private float timer;
    public float delay;
    private bool daggerThrown;
    private GameObject thrownDagger;
    
    public bool teleported;

    public override void Activate(GameObject parent)
    {
        firing = true;
    }

    public override void Deactivate(GameObject parent) 
    {
        firing = false;
    }

    public override void Init() {
        firing = false;
        teleported = false;
        daggerThrown = false;
        canFire = true;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public override void AbilityBehavior(GameObject parent) {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (!canFire) {
            timer += Time.deltaTime;
            if (timer > delay) {
                canFire = true;
                timer = 0;
            }
        }

        if (firing && !daggerThrown && canFire) {
            daggerThrown = true;
            canFire = false;
            teleported = false;
            thrownDagger = Instantiate(dagger, parent.transform.GetChild(0).GetChild(0).transform.position, Quaternion.identity);
            firing = false;
        } else if (firing && daggerThrown && canFire) {
            daggerThrown = false;
            canFire = false;
            teleported = true;
            parent.transform.position = thrownDagger.transform.position;
            Destroy(thrownDagger);
            firing = false;
        }
    }

    public override void AbilityHandler(GameObject parent) {
        switch (state) 
        {
            case AbilityState.ready:
                if (abilityPressed) {
                    Activate(parent);
                    state = AbilityState.reactive;
                    fillAmount = 1;
                    abilityPressed = false;
                }
            break;
            case AbilityState.reactive:
                if (abilityPressed) {
                    Activate(parent);
                    state = AbilityState.active;
                }
            break;
            case AbilityState.active:
                if (teleported == true) {
                    currentCooldownTime = cooldownTime;
                    state = AbilityState.cooldown;
                }
            break;
            case AbilityState.cooldown:
                if (currentCooldownTime > 0) {
                    currentCooldownTime -= Time.deltaTime;
                    fillAmount -= 1/cooldownTime * Time.deltaTime;
                } else {
                    state = AbilityState.ready;
                    fillAmount = 1;
                }
            break;
        }
    }
}
