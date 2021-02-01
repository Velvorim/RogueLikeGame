using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCenter : MonoBehaviour
{

    public bool openWhenEnemiesCleared;

    public List<GameObject> enemies = new List<GameObject>();

    public Room theRoom;



    // Start is called before the first frame update
    void Start()
    {
        if (openWhenEnemiesCleared)
        {
            theRoom.closeWhenEntered = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 0 && theRoom.roomActive && openWhenEnemiesCleared)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
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
                theRoom.OpenDoors();
            }

        }
    }
}
