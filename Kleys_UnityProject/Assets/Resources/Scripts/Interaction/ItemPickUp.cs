
using UnityEngine;

public class ItemPickUp : Interactable
{
    [SerializeField] SOItem item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Pick" + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
