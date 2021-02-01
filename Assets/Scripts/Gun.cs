using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletToFire;
    public Transform firePoint;

    public float timeBeteewnShoot;
    private float shotCounter;

    public string weaponName;
    public Sprite genUI;

    public int itemCost;
    public Sprite gunShopSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the game is paused 
        if(PlayerController.instance.canMove && !LevelManager.instance.isPaused)
        { 
            if(shotCounter > 0)
            {
                shotCounter -= Time.deltaTime;
            } else
            {
                //fire bullets and get automatic shoot whn cliked 
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
                {
                    Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                    shotCounter = timeBeteewnShoot;
                    AudioManager.instance.PlaySFX(12);

                }
            }
         
  
          //shoot automatic when cliked
           /* if (Input.GetMouseButton(0))
            {
              shotCounter -= Time.deltaTime;

              if (shotCounter <= 0)
              {
                  Instantiate(bulletToFire, firePoint.position, firePoint.rotation);

                  shotCounter = timeBeteewnShoot;

                  AudioManager.instance.PlaySFX(12);

              }
            }*/
        }
    }
}
