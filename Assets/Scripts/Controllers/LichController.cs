using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichController : Controller
{
    bool hasShield;
    // Start is called before the first frame update
    void Start()
    {
        hasShield = true;
    }

    public void RemoveShield()
    {
        hasShield = false;
    }

    public bool HasShield()
    {
        return hasShield;
    }
}
