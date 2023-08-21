using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private bool firing;
    public GameObject bullet;
    public Transform bulletTransform;
    private bool canFire;
    private float timer;
    public float fireRate;
    

    // Start is called before the first frame update
    void Start()
    {
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
            if (timer > fireRate) {
                canFire = true;
                timer = 0;
            }
        }

        if (firing && canFire) {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

    public void Fire() {
        firing = true;
    }

    public void Stop() {
        firing = false;
    }
}