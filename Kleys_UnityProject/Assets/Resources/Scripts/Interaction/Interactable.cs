using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] bool canInteract = false;
    int playerLayer = 1 << 10;
    Player player;
    private void Update()
    {
        GenerateSphere();
        CanInteract();
    }

    private void GenerateSphere()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);

        if(colliders.Length > 0 && canInteract == false)
        {
            player = colliders[0].gameObject.GetComponent<Player>();
        }
    }

    private void CanInteract()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            canInteract = true;

            if (distance >= radius)
            {
                canInteract = false;
                player = null;
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        //This method is meant to be overrwritten 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
