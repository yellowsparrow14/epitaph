using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;

public class RayCastTrigger : MonoBehaviour
{
    //public Transform laserHit;
    public LineRenderer lineRenderer;
    private Camera mainCamera;
    private Vector3 mousePos;
    private WaitForSeconds shotDuration = new WaitForSeconds(3f);
    private bool firing;

    private float rayWidth;
    private float range;
    private float damage;
    private float tickRate;

    private bool canTick;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canTick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firing) {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, mousePos + new Vector3(0,0,10));
            lineRenderer.enabled = true;

            LayerMask mask = LayerMask.GetMask("Enemy");
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, rayWidth/2, mousePos - transform.position, range, mask, -5, 5);

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
                    Debug.Log(hit);
                    canTick = false;
                }

            }

        } else {
            lineRenderer.enabled = false;
        }

        //Debug.Log(Input.mousePosition);
        //Debug.Log(transform.position);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos);
        //Debug.DrawLine(transform.position, mousePos, Color.green, 2, false);
        //if(hit != null) {
        //    Debug.Log("hi");
        //    laserHit.position = hit.point;
        //}
        //Debug.Log(hit.transform.position);
        //ignore raycast for now, just do line renderer


    }

    public void Fire(float rayWidth, float range, float damage, float tickRate)
    {
        // StartCoroutine(RayEffect());
        // Debug.Log("FIRE");
        // mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // lineRenderer.SetPosition(0, transform.position);
        // lineRenderer.SetPosition(1, mousePos + new Vector3(0,0,10));
        firing = true;
        this.rayWidth = rayWidth;
        this.range = range;
        this.damage = damage;
        this.tickRate = tickRate;
    }

    public void Stop()
    {
        firing = false;
    }

    // private IEnumerator RayEffect() 
    // {
    //     lineRenderer.SetPosition(0, transform.position);
    //     lineRenderer.SetPosition(1, mousePos + new Vector3(0,0,10));
    //     Debug.Log(transform.position);
    //     Debug.Log(mousePos);
    //     lineRenderer.enabled = true;
    //     Debug.Log("reached");
    //     yield return shotDuration;

    //     lineRenderer.enabled = false;

    // }
}
