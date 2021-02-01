using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public bool closeWhenEntered /* , openWhenEnemiesCleared this and the parts of code comented stay on the RoomCenter Script */;

    public GameObject[] doors;

    //public List<GameObject> enemies = new List<GameObject>();

    [HideInInspector]
    public bool roomActive;

    public GameObject mapHider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if(enemies.Count > 0 && roomActive && openWhenEnemiesCleared)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i] == null)
                {
                    enemies.RemoveAt(i);

                    // this decrement is very important because, whitout him the for will takes the the elemente when the enemie was destroyed,
                    //and back to loop make a bug whit dont will open the door correctly
                    i--;
                }
            }

            //make the door stay open when the player clear the room
            if (enemies.Count == 0)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(false);

                    closeWhenEntered = false;
                }
            }

        } */
    }

    public void OpenDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);

            closeWhenEntered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //make the door stay close when the player enter in the room
        if (other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);

            if (closeWhenEntered)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(true);
                }
            }

            roomActive = true;

            mapHider.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //this will dont render when the player leave the room, the same thing for the trigger enter, only when his enter 
        if (other.tag == "Player")
        {
            roomActive = false;
        }
    }

}
