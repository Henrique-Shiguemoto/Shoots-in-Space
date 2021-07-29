using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    void Update()
    {
        transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * cameraSpeed;
    }
}
