using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeLevel : MonoBehaviour {
    public enum Level {
        Single,
        Double,
        Full
    }
    public Level level = Level.Single;
}
