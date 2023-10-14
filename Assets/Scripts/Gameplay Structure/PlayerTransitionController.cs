using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTransitionController : MonoBehaviour
{
    // Start is called before the first frame update
    private Boundaries playerBoundaries;

    private SceneTransitionManager sceneTransitionManager;
    void Start()
    {
        playerBoundaries = this.transform.GetComponent<Boundaries>();
        sceneTransitionManager = GameObject.FindGameObjectWithTag("LevelController").GetComponent<SceneTransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > playerBoundaries.yBounds.y - playerBoundaries.widthHeight.y/2) {
            sceneTransitionManager.OnRunEnd();
            Debug.Log("Run End");
        }
    }
}
