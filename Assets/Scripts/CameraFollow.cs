using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 5f, -8f);

    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}