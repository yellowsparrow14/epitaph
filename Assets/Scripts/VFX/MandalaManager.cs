using UnityEngine;

public class MandalaManager : MonoBehaviour {
    [SerializeField] private Transform axis;
    [SerializeField] private Transform mandala;

    void UpdateMandala(Vector3 mousePos) {
        Vector3 d = mousePos-transform.position;
        Vector3 p = projectAgainstAxis(d);

        float a = Vector3.SignedAngle(Vector3.right, p, Vector3.up) - 90;
        var prevRot = axis.localEulerAngles;
        prevRot.y = a;
        axis.localEulerAngles = prevRot;
    }

    void Update() {
        var mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        UpdateMandala(mousePos);
    }

    public Vector3 projectAgainstAxis(Vector3 p) {
        Vector3 axisV = axis.rotation * Vector3.up;
        float newZ = -(axisV.x * p.x + axisV.y * p.y)/axisV.z;
        return new Vector3(p.x, p.y, newZ);
    }

    public Vector2 GetMandalaCenter() {
        return (Vector2)mandala.position;
    }

    void OnGizmosSelected() {
        
    }
}