using UnityEngine;

public class GameUnitBase : MonoBehaviour
{
    public Transform TransformData { get; private set; }

    public Vector3 SelfPosition() => TransformData.position;

    public Quaternion SelfRotation() => TransformData.rotation;

    protected virtual void Awake()
    {
        TransformData = transform;
    }
}