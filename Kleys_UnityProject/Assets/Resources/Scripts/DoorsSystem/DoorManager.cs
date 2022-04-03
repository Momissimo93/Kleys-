using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] MagicDoor magicDoor;
    private void OnTriggerEnter(Collider collision)
    {
        Player p;
        if (collision.gameObject.GetComponent<Player>())
        {
            p = collision.gameObject.GetComponent<Player>();
            if(p.Get_KeyNumber() == 2)
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
