using UnityEngine;
using Cinemachine;

[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class LockCamera : CinemachineExtension
{
    [Tooltip("Lock the camera's Z position to this value")]
    public float m_XPosition = 10;

    private GameObject walkable;

    void Start() {
        walkable = GameObject.FindWithTag("Walkable");
    }
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = m_XPosition;

            Vector2 walkablePos = walkable.transform.position;
            float walkableHeight = walkable.GetComponent<SpriteRenderer>().bounds.size.y;
            pos.y = Mathf.Clamp(pos.y, walkablePos.y - walkableHeight/2, walkablePos.y + walkableHeight/2);
            
            state.RawPosition = pos;
        }
    }
}
 