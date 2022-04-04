
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create ItemPickUp")]
public class SOItemPickUp : ScriptableObject
{
    new public string name;
    public bool isKey;
    public bool isCursed;
    public GameObject item;
}
