using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTrigger : MonoBehaviour
{
    //public Transform laserHit;
    public LineRenderer lineRenderer;
    private Camera mainCamera;
    private Vector3 mousePos;
    private WaitForSeconds shotDuration = new WaitForSeconds(3f);
    private bool firing;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firing) {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, mousePos + new Vector3(0,0,10));
            lineRenderer.enabled = true;
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

    public void Fire()
    {
        // StartCoroutine(RayEffect());
        // Debug.Log("FIRE");
        // mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // lineRenderer.SetPosition(0, transform.position);
        // lineRenderer.SetPosition(1, mousePos + new Vector3(0,0,10));
        firing = true;
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
