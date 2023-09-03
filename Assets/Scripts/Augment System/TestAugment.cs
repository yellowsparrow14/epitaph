using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAugment : MonoBehaviour
{
    [SerializeField]
    private Augment augment;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            augment.enableAugment();
        }
    }
}
