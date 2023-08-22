using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDaggerTrigger : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private bool firing;
    public GameObject dagger;
    public Transform daggerTransform;
    private bool canFire;
    private float timer;
    public float delay;

    private GameObject player;
    private bool daggerThrown;
    private GameObject thrownDagger;
    
    public bool teleported;
    
    // Start is called before the first frame update
    void Start()
    {
        firing = false;
        teleported = false;
        daggerThrown = false;
        canFire = true;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
         
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
            thrownDagger = Instantiate(dagger, daggerTransform.position, Quaternion.identity);
            Stop();
        } else if (firing && daggerThrown && canFire) {
            daggerThrown = false;
            canFire = false;
            teleported = true;
            player.transform.position = thrownDagger.transform.position;
            Destroy(thrownDagger);
            Stop();
        }
    }

    public void Fire(GameObject player) {
        this.player = player;
        firing = true;
    }

    public void Stop() {
        firing = false;
    }
}
