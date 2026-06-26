using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float height;


    void LateUpdate()
    {
        transform.position = target.position + offset; // position the camera relative to the target and the offset
    }
}
