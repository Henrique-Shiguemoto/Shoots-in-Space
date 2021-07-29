using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public float parallaxScale;
    private float textureUnitSize;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        //Getting the unit size of the background
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSize = texture.height / sprite.pixelsPerUnit;
    }

    //LateUpdate is called after all Update functions have been called. (Unity Documentation)
    void LateUpdate()
    {
        //How much the camera has moved since the last frame
        Vector3 deltaCameraMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaCameraMovement * parallaxScale;

        //Setting the last camera position to the current position for the next Update() call
        lastCameraPosition = cameraTransform.position;

        //Checking if we need to reposition the background to make the infinite background illusion
        if(cameraTransform.position.y - transform.position.y >= textureUnitSize){
            float offsetPosition = (cameraTransform.position.y - transform.position.y) % textureUnitSize;
            transform.position = new Vector3(0f, cameraTransform.position.y + offsetPosition, 0f); //reposition
        }
    }
}
