using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : Commands
{
    public override void Move (Transform transform, Vector2 vector2)
    {
        if(transform.gameObject.GetComponent<Player> ())
        {
            player = transform.gameObject.GetComponent<Player>();

            if (transform.gameObject.GetComponent<Rigidbody>())
            {
                rigidbody = transform.gameObject.GetComponent<Rigidbody>();
                rigidbody.velocity = transform.TransformDirection(new Vector3(vector2.x * player.Speed, rigidbody.velocity.y, vector2.y * player.Speed));
            }
        }
    }
}
