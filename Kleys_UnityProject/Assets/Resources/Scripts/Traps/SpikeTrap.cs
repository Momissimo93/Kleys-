using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Vector3 originalPosition;
    private Transform transform;
    private VerticalMovement verticalMovement;
    private float distance = 1.2f;
    private int initialDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        originalPosition = transform.position;
        verticalMovement = gameObject.AddComponent<VerticalMovement>();
        verticalMovement.SetParameters(transform, originalPosition, distance, initialDirection);
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement.Move(transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.GetComponent<Human>() && collision.gameObject.GetComponent<Human>().isOnPlatform == false)
        {
            collision.transform.SetParent(transform);
            collision.gameObject.GetComponent<Human>().isOnPlatform = true;
        }*/
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.GetComponent<Human>() && collision.gameObject.GetComponent<Human>().isOnPlatform == true)
        {
            collision.transform.SetParent(null);
            collision.gameObject.GetComponent<Human>().isOnPlatform = false;
            //collision.gameObject.GetComponent<Human>().isNotOnPlatform = true;

        }*/
    }
}
