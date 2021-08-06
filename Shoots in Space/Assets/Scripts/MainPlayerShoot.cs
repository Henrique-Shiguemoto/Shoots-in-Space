using UnityEngine;

public class MainPlayerShoot : MonoBehaviour
{
    //Public variables
    public GameObject spaceShipShot;

    //Private variables
    private const float TIME_BETWEEN_SHOTS = 0.15f;
    private float nextShotTime = 0f;
    
    void Update()
    {
        //shots have cooldown, the player can only shoot if TIME_BETWEEN_SHOTS have passed after the last shot
        if(Time.time > nextShotTime){
            if(Input.GetButton("Fire1")){
                FindObjectOfType<AudioManager>().PlaySound("LazerShot");
                Vector3 bulletPosition1 = new Vector3(0f, 0.4f, 0f) + transform.position;
                Instantiate(spaceShipShot, bulletPosition1, Quaternion.identity);
                nextShotTime = Time.time + TIME_BETWEEN_SHOTS;
            }
        }
    }
}
