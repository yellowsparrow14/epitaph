using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Default coin value is 10
    public int coinValue = 10;
    // public int CurrencyVal => _value;

    protected Rigidbody2D rb;
    
    // Use if coins should expire after some time
    // [SerializeField] protected float despawnTimer;

    // Start is called before the first frame update
    protected virtual void Start() {}

    // Update is called once per frame
    protected virtual void Update()
    {
        // if (projectileTimer > 0)
        // {
        //     projectileTimer -= Time.deltaTime;
        //     return;
        // }
        // Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            var player = other.GetComponent<Player>();
            if (player != null) {
                player.CollectCoin(coinValue);
            }
             Debug.Log($"Coin collected by player");
             Destroy(this.gameObject);
        }
    }

    public void setCoinValue(int value) {
        coinValue = value;
    }
}
