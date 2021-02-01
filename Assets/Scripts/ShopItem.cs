using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public GameObject buyMessage;

    private bool inBuyZone;

    public bool isHealthRestore, isHealthUpgrade, isWeapon;

    public int itemCost;

    public int healthUpgradeAmount;

    public Gun[] potetialGuns;
    private Gun theGun;
    public SpriteRenderer gunSprite;
    public Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        if (isWeapon)
        {
            int selectedGun = Random.Range(0, potetialGuns.Length);
            theGun = potetialGuns[selectedGun];

            gunSprite.sprite = theGun.gunShopSprite;
            infoText.text = theGun.weaponName + "\n - " + theGun.itemCost + " Gold -";
            itemCost = theGun.itemCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inBuyZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(LevelManager.instance.currentCoins >= itemCost)
                {
                    LevelManager.instance.SpendCoins(itemCost);

                    if (isHealthRestore)
                    {
                        PlayerHealthController.instance.HealPlayer(PlayerHealthController.instance.maxHealth); 
                    }

                    if (isHealthUpgrade)
                    {
                        PlayerHealthController.instance.IncreaseMaxHealth(healthUpgradeAmount);
                    }

                    if(isWeapon)
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


                    gameObject.SetActive(false);
                    inBuyZone = false;

                    AudioManager.instance.PlaySFX(18);
                }else
                {
                    AudioManager.instance.PlaySFX(19);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            buyMessage.SetActive(true);

            inBuyZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buyMessage.SetActive(false);

            inBuyZone = false;
        }
    }
}
