using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FallingCheck : MonoBehaviour
{
    private Player player;
    private JumpManager jumpManager;
    float distance;
    void Start()
    {
        //When the class is activated it takes a reference to the Player Game Object it is attached to in order to comunicate with it 
        if(gameObject.GetComponent<Player>())
        {
            player = gameObject.GetComponent<Player>();
        }
        else
        {
            Debug.Log("Error: No capsule Collider found");
        }
    }
    public void Constructor(JumpManager j)
    {
        jumpManager = j;
    }
    //The method communicate directly with the Player game Object asking whathever it is on the ground or it is jumping 
    public bool IsFalling()
    {
        if (player.Get_IsOnGround() == false && player.Get_IsJumping() == true)
        {
            //The method returns true when the new distance is less then the previous distance that was stored --> meaning that the player is actully falling along the y axis 
            float newDistance = jumpManager.distance;

            if (distance == 0 || newDistance > distance)
            {
                distance = newDistance;
                return false;
            }
            else if (newDistance < distance)
            {
                distance = newDistance;
                return true;
            }
            distance = newDistance;
        }
        else if (player.Get_IsOnGround() == false && player.Get_IsJumping() == false)
        {
            //The player is also falling if the abovementioned conditions are true; basically if suddently does not have the ground under his feet 
            return true;
        }
        return false;
    }
}
