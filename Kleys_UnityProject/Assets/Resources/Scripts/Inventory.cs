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

    public List<SOItem> sOItems = new List<SOItem>();
    public bool hasAllKeys = false;
    public void Add(SOItem item)
    {
        if(item.isCursed && item.isKey)
        {
            if(Check(item))
            {
                sOItems.Add(item);
            }
            else
            {
                Debug.Log("DEAD");
            }
        }
        else
        {
            sOItems.Add(item);
        }
    }

    bool Check (SOItem item)
    {
        if (item.name == "Silver_Key")
        {
            Debug.Log("True we have the Silver_Key");
            if(sOItems.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (SOItem i in sOItems)
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
    public bool HasItem(string name)
    {
        if (sOItems.Count == 0)
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
        foreach (SOItem i in sOItems)
        {
            if (i.name == s)
            {
                return true;
            }
        }
        return false;
    }
}
