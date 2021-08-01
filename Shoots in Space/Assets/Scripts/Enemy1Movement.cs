using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    private Vector3 cameraPosition;
    private float cameraSpeed;
    private float enemySpeed;

    //Value multiplier in (0f, 1f), will down scale the enemy speed in relation to the camera
    public float enemySpeedDownScale;
    void Start()
    {
        cameraPosition = Camera.main.transform.position;
        cameraSpeed = Camera.main.GetComponent<CameraMovement>().cameraSpeed;
        enemySpeed = cameraSpeed * enemySpeedDownScale;
    }

    void Update()
    {
        transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * enemySpeed;
    }
}
