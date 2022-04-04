using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] MagicDoor magicDoor;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if(Inventory.instance.HasItem("Golden_Key") && Inventory.instance.HasItem("Silver_Key"))
            {
                Debug.Log("Enough_Key");
                magicDoor.OpenDoor();
            }
            else
            {
                Debug.Log("Not enough key");
            }
        }
    }
}
