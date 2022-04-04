using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance found");
        }

        instance = this; 
    }
    #endregion

    public List<SOItemPickUp> inventory = new List<SOItemPickUp>();
    public bool hasAllKeys = false;
    public void Add(SOItemPickUp item)
    {
        /*
        Debug.Log("Add " + item.name);
        if(item.isCursed && item.isKey)
        {
            if(Check(item))
            {
                Debug.Log("The item is cursed");
                inventory.Add(item);
            }
            else
            {
                Debug.Log("DEAD");
            }
        }
        else
        {
            inventory.Add(item);
        }*/

        inventory.Add(item);
    }

    /*bool Check (SOItemPickUp item)
    {
        if (item.name == "Silver_Key")
        {
            Debug.Log("True we have the Silver_Key");
            if(inventory.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (SOItemPickUp i in inventory)
                {
                    if (i.name != "Golden_Key")
                    {
                        return false;
                    }
                    else
                    {
                        hasAllKeys = true;
                        return true;
                    }
                }
            }
        }
        else
        {
            return true;
        }
        return true;
    }
    */
    public bool HasItem(string name)
    {
        if (inventory.Count == 0)
        {
            return false; 
        }
        else
        {
            return Search(name);
        }
    }

    bool Search(string s)
    {
        foreach (SOItemPickUp i in inventory)
        {
            if (i.name == s)
            {
                return true;
            }
        }
        return false;
    }
}
