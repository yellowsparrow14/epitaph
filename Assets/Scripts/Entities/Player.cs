using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public override void Die() {
        Destroy(gameObject);
        SceneManager.LoadScene("DeathScreen");

    }

}
