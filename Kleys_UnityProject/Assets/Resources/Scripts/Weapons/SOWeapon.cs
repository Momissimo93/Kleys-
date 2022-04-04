
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Create Weapon")]
public class SOWeapon : ScriptableObject
{
    new public string name;
    public int damage;
    public GameObject item;
}
