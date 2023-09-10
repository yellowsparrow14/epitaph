using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTerrain : MonoBehaviour
{
    //variable
    [SerializeField] private string source;
    [SerializeField] private float healAmount;
    [SerializeField] private float timeInterval;
    public GameObject entity;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(source))
        {
            entity = collision.gameObject;
            InvokeRepeating("Heal", 0f, timeInterval);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
    }

    private void Heal()
    {
        entity.gameObject.GetComponent<Entity>().Health.Heal(healAmount);
        Debug.Log("healed");
    }

    public void SetSource(string sourceName)
    {
        source = sourceName;
    }
   
}
