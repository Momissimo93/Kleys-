using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject magicTiles;
    Player p;
    // Start is called before the first frame update

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit" + other);
        if (other.gameObject.GetComponent<Player>())
        {
            p = other.gameObject.GetComponent<Player>();
            if (!CheckGoldKey())
            {
                Destroy(magicTiles);
                Debug.Log("GameOver");
            }
            else
            {
                Debug.Log("Ok");
            }
        }
    }
    bool CheckGoldKey ()
    {
        if(Inventory.instance.HasItem("Golden_Key"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
