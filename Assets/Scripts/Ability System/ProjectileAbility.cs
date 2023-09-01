using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileAbility : Ability
{
    private Camera mainCamera;
    private Vector3 mousePos;
    private bool firing;
    public GameObject bullet;

    //public GameObject bulletSpawner;
    //public Transform bulletTransform;
    
    private bool canFire;
    private float timer;
    public float fireRate;

    public override void Activate(GameObject parent)
    {
        firing = true;
    }

    public override void Deactivate(GameObject parent) 
    {
        firing = false;
    }

    public override void Init() {
        //bulletTransform = bulletSpawner.transform;
        canFire = true;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public override void AbilityBehavior(GameObject parent) {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - parent.transform.GetChild(0).transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        parent.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, rotZ);
         
        if (!canFire) {
            timer += Time.deltaTime;
            if (timer > fireRate) {
                canFire = true;
                timer = 0;
            }
        }

        if (firing && canFire) {
            canFire = false;
            Instantiate(bullet, parent.transform.GetChild(0).GetChild(0).transform.position, Quaternion.identity);
        }
    }

    public override void AbilityHandler(GameObject parent) {
        switch (state) 
        {
            case AbilityState.ready:
                if (abilityPressed) {
                    Activate(parent);
                    state = AbilityState.active;
                    currentActiveTime = activeTime;
                    fillAmount = 1;
                }
            break;
            case AbilityState.active:
                if (currentActiveTime > 0) {
                    currentActiveTime -= Time.deltaTime;
                } else {
                    state = AbilityState.cooldown;
                    currentCooldownTime = cooldownTime;
                    Deactivate(parent);
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