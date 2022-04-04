
using UnityEngine;

public class ItemPickUp : Interactable
{
    [SerializeField] new string name;
    [SerializeField] bool isCursed;
    [SerializeField] bool isKey;
    [SerializeField] SOItemPickUp item;

    void PickUp()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public override void ItemStats()
    {
        name = item.name;
        isCursed = item.isCursed;
        isKey = item.isKey;
    }
}
