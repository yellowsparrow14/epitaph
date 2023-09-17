using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DebugToggleAugments : MonoBehaviour
{
    [SerializeField]
    private AugmentManager augmentManager;
    
    private bool active = false;

    private void Awake()
    {
        this.augmentManager = gameObject.GetComponent<AugmentManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!active) {
                Debug.Log("Starting Coroutines");
                augmentManager.startCoroutines();
                active = !active;
            }
            else {
                Debug.Log("Stopping Coroutines");
                augmentManager.stopAllCoroutines();
                active = !active;
            } 
        }
    }
}
