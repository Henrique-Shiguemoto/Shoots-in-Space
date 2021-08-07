using UnityEngine;
using TMPro;

public class MainPlayerShoot : MonoBehaviour
{

    [SerializeField] private GameObject spaceShipShot;
    [SerializeField] private GameObject specialAbilityShot;
    private const float SPECIAL_ABILITY_COOLDOWN = 6f;
    private const float SPECIAL_ABILITY_TIME = 3f;
    private const float TIME_BETWEEN_SHOTS = 0.15f;
    private float whenSpecialAbilityFinishes = 0f;
    private float nextSpecialAbilityTime = 0f;
    private float nextShotTime = 0f;
    private bool isUsingSpecialAbility = false;

    void Update()
    {
        //shots have cooldown, the player can only shoot if TIME_BETWEEN_SHOTS have passed after the last shot
        if(Time.time >= nextShotTime && !isUsingSpecialAbility){
            if(Input.GetButton("Fire1")){
                FindObjectOfType<AudioManager>().PlaySound("LazerShot");
                Vector3 bulletPosition1 = new Vector3(0f, 0.4f, 0f) + transform.position;
                Instantiate(spaceShipShot, bulletPosition1, Quaternion.identity);
                nextShotTime = Time.time + TIME_BETWEEN_SHOTS;
            }
        }
        if(Time.time >= nextSpecialAbilityTime){
            isUsingSpecialAbility = false;
            if(Input.GetKeyDown(KeyCode.E)){
                FindObjectOfType<AudioManager>().PlaySound("SpecialAbility");
                isUsingSpecialAbility = true;
                nextSpecialAbilityTime = Time.time + SPECIAL_ABILITY_COOLDOWN;
                whenSpecialAbilityFinishes = Time.time + SPECIAL_ABILITY_TIME;
            }
        }
        if(Time.time <= whenSpecialAbilityFinishes){
            if(isUsingSpecialAbility){
                if(Time.time >= nextShotTime){
                    Vector3 specialAbilityShotPosition = transform.position + new Vector3(0f, 0.4f, 0f);
                    Instantiate(specialAbilityShot, specialAbilityShotPosition, Quaternion.identity);
                    nextShotTime = Time.time + TIME_BETWEEN_SHOTS;
                }
            }
        }else{
            isUsingSpecialAbility = false;
        }
    }
}
