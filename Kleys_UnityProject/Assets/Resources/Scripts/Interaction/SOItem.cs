
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create Item")]
public class SOItem : ScriptableObject
{
    new public string name;
    public bool isKey;
    public bool isCursed;
    public GameObject item;

}
