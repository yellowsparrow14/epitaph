using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

[CreateAssetMenu]
public class RayCastAbility : Ability
{
    private LineRenderer lineRenderer;
    private ParticleSystem tipParticles;
    private Camera mainCamera;
    private Vector3 mousePos;
    private bool firing;

    public float rayWidth;
    public float range;
    public float damage;
    public float tickRate;

    private bool canTick;
    private float timer;

    private Vector3 _prevPos;
    [SerializeField] private float _laserSpeed = 0.5f;

    public override void Activate(GameObject parent)
    {
        firing = true;
    }

    public override void Deactivate(GameObject parent) 
    {
        firing = false;
    }

    public override void Init()
    {
        lineRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        tipParticles = lineRenderer.GetComponentInChildren<ParticleSystem>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canTick = true;   
    } 

    private void SetLineRMatLen(float len) {
        lineRenderer.material.SetFloat("_Length", len);
    }

    private void SetTipParticleEnabled(bool b) {
        var e = tipParticles.emission; //Have to store in variable to prevent runtime error
        e.enabled = b;
    }

    public override void AbilityBehavior(GameObject parent) {
        if (firing) {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 pos1 = parent.transform.GetChild(0).transform.position;
            Vector3 pos2 = mousePos + new Vector3(0,0,10);
            pos2 = Vector3.MoveTowards(_prevPos, pos2, _laserSpeed);

            _prevPos = pos2;

            lineRenderer.SetPosition(0, pos1);
            lineRenderer.SetPosition(1, pos2);
            lineRenderer.enabled = true;
            tipParticles.transform.position = pos2;
            SetTipParticleEnabled(true);

            float len = (pos2-pos1).magnitude;
            SetLineRMatLen(len);

            LayerMask mask = LayerMask.GetMask("Enemy");
            RaycastHit2D[] hits = Physics2D.CircleCastAll(parent.transform.GetChild(0).transform.position, rayWidth/2, mousePos - parent.transform.GetChild(0).transform.position, range, mask, -5, 5);
            foreach (RaycastHit2D hit in hits) {
                if (!canTick) {
                    timer += Time.deltaTime;
                    if (timer > tickRate) {
                        canTick = true;
                        timer = 0;
                    }
                }

                if (canTick) {
                    hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    canTick = false;
                }

            }

        } else {
            lineRenderer.enabled = false;
            SetTipParticleEnabled(false);
        }
    }

    public override void AbilityCooldownHandler(GameObject parent) {
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
