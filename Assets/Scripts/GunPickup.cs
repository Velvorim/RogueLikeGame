using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public Gun theGun;

    public float waitToBeCollected = .5f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (waitToBeCollected > 0)
        {
            waitToBeCollected -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && waitToBeCollected <= 0)
        {
            bool hasGun = false;
            foreach(Gun gunToCheck in PlayerController.instance.availableGuns)
            {
                if(theGun.weaponName == gunToCheck.weaponName)
                {
                    hasGun = true;
                }
            }

            if (!hasGun)
            {
                Gun gunclone = Instantiate(theGun);
                gunclone.transform.parent = PlayerController.instance.gunArm;
                gunclone.transform.position = PlayerController.instance.gunArm.position;
                gunclone.transform.localRotation = Quaternion.Euler(Vector3.zero);
                gunclone.transform.localScale = Vector3.one;

                PlayerController.instance.availableGuns.Add(gunclone);
                PlayerController.instance.currentGun = PlayerController.instance.availableGuns.Count - 1;

                PlayerController.instance.SwitchGun();
            }

            Destroy(gameObject);

            AudioManager.instance.PlaySFX(7);
        }


    }
}
