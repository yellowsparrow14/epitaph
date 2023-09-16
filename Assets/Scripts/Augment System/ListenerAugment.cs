using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerAugment : Augment
{
    private float interval;

    private bool coroutineStarted;

    public bool getCoroutineStarted()
    {
        return coroutineStarted;
    }

    public void setCoroutineStarted(bool value)
    {
        this.coroutineStarted = value;
    }

    public virtual IEnumerator passiveBehavior(Player player)
    {
        yield return new WaitForSeconds(interval);
    }
}
