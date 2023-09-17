using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentManager : MonoBehaviour
{
    [SerializeField]
    private Entity current;

    private Entity target;

    private float damageTaken = 0;

    private float damageDealt = 0;

    // active augments should be handled in the backend, no need to expose
    private List<OnHitAugment> onHitAugments = new List<OnHitAugment>();
    private List<ListenerAugment> listenerAugments = new List<ListenerAugment>();

    public void startCoroutines()
    {
        foreach (ListenerAugment augment in listenerAugments)
        {
            augment.setCoroutineStarted(false);
            if (!augment.getCoroutineStarted())
            {
                augment.setCoroutineStarted(true);
                StartCoroutine(augment.passiveBehavior(current));
            }
        }
    }

    public void stopAllCoroutines() {
        StopAllCoroutines();
    }

    public void setCurrent(Entity current)
    {
        this.current = current;
    }

    // called whenever the player takes damage
    public void updateDamageTaken(float damage)
    {
        this.damageTaken = damage;
        takeAugmentedDamage();
    }

    // called whenever the player deals damage
    public void updateDamageDealt(Entity target, float damage)
    {
        this.target = target;
        this.damageDealt = damage;
        dealAugmentedDamage();
    }

    // this applies the augment AFTER we already took damage
    public void takeAugmentedDamage()
    {
        foreach (OnHitAugment augment in onHitAugments)
        {
            current.TakeDamageAugmented(augment.applyAugmentDamageTaken(damageTaken, current, target));
        }
    }

    // applies the augment AFTER we already deal damage
    public void dealAugmentedDamage()
    {
        foreach(OnHitAugment augment in onHitAugments)
        {
            current.DealDamageAugmented(target, augment.applyAugmentDamageDealt(damageDealt, current, target));
        }
    }

    public void addAugment(Augment augment) {
        Debug.Log("Adding augment");
        Debug.Log(augment.GetType());
        if (augment is OnHitAugment) {
            Debug.Log("Adding OnHitAugment");
            onHitAugments.Add((OnHitAugment)augment);
        }
        if (augment is ListenerAugment) {
            Debug.Log("Adding ListenerAugment");
            listenerAugments.Add((ListenerAugment)augment);
        }
    }

    public void clearAugments() {
        Debug.Log("[Augment Manager] Clearing all augments");
        onHitAugments.Clear();
        listenerAugments.Clear();

    }

    // public void addOnHitAugment(OnHitAugment augment)
    // {
    //     onHitAugments.Add(augment);
    // }

    // // deactive on hit augments
    // public void removeAugment(OnHitAugment augment)
    // {
    //     onHitAugments.Remove(augment);
    // }

    // // add active augments
    public void addListenerAugment(ListenerAugment augment)
    {
        listenerAugments.Add(augment);
    }

    // // deactive augments
    // public void removeListenerAugment(ListenerAugment augment)
    // {
    //     listenerAugments.Remove(augment);
    // }



}
