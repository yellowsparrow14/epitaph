using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    
    //basic boundaries for player/possible enemies

    private Vector2 bounds;
    private Vector2 widthHeight;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        widthHeight = this.gameObject.GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        float x = Mathf.Clamp(this.transform.position.x, bounds.x*-1 + widthHeight.x/2, bounds.x - widthHeight.x/2);
        this.transform.position = new Vector2(x, this.transform.position.y);
    }
}
