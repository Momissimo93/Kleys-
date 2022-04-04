using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    SOWeapon itemModel;
    GameObject item;
    Player player;

    private void Start()
    {
        if(gameObject.GetComponent<Player>())
        {
            player = gameObject.GetComponent<Player>();
        }
    }
    public void SpawnItem (string name)
    {
        if(name == "Torch")
        {
            if (Resources.Load("ScriptableObject/Weapons/Torch"))
            {
                itemModel = Object.Instantiate(Resources.Load("ScriptableObject/Weapons/Torch")) as SOWeapon;
                item = GameObject.Instantiate(itemModel.item) as GameObject;
                SetItem();
            }
            else
            {
                Debug.Log("Error I could not find the Player Scriptable Object");
            }
        }
        void SetItem()
        {
            //The folloing code will set the player in the correct position at the start of the level 

            //1) Make leonard game object a child of the Leonard game object in the Hierarchy window so we can easily find it 
            item.transform.SetParent(player.transform.Find("mixamorig9:Hips/mixamorig9:Spine/mixamorig9:Spine1/mixamorig9:Spine2/mixamorig9:RightShoulder/mixamorig9:RightArm/mixamorig9:RightForeArm/mixamorig9:RightHand").gameObject.transform);
            //2) Reset the position
            item.transform.position = player.transform.Find("mixamorig9:Hips/mixamorig9:Spine/mixamorig9:Spine1/mixamorig9:Spine2/mixamorig9:RightShoulder/mixamorig9:RightArm/mixamorig9:RightForeArm/mixamorig9:RightHand/PickPos").gameObject.transform.position;
            item.transform.localEulerAngles = player.transform.Find("mixamorig9:Hips/mixamorig9:Spine/mixamorig9:Spine1/mixamorig9:Spine2/mixamorig9:RightShoulder/mixamorig9:RightArm/mixamorig9:RightForeArm/mixamorig9:RightHand/PickPos").gameObject.transform.localEulerAngles;
        }
    }
    
    public GameObject GetReference()
    {
        return item;
    }
}
 