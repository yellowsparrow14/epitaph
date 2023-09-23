using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{   
    public GameObject coin;

    public override void Die() {
        Vector2 pos = this.transform.GetChild(0).GetChild(0).transform.position;
        DropCoin(pos);
        Destroy(gameObject);
    }

    public void DropCoin(Vector2 pos) {
        Debug.Log("dropped a coin");
        GameObject copyCoin = Instantiate(coin, pos, Quaternion.identity) as GameObject;
        copyCoin.transform.position = this.transform.position;
        // copyCoin.setActive(true);
    }

}
