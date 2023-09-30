using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{   
    // This GameObject dictates how much the enemy is "worth" in money
    // Currently there are 3 types of coins: 10 Coin, 20 Coin, 30 Coin.
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
        switch (coin.gameObject.name) {
            default:
            case "10 Coin":
                copyCoin.GetComponent<Coin>().setCoinValue(10);
                break;
            case "20 Coin":
                copyCoin.GetComponent<Coin>().setCoinValue(20);
                break;
            case "30 Coin":
                copyCoin.GetComponent<Coin>().setCoinValue(30);
                break;
        }
    }

}
