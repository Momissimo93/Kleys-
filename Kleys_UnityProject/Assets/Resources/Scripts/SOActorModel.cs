//The purpose of this scriptable object is to hold general values for each of the game objects it is given to

using UnityEngine;

[CreateAssetMenu(fileName = "Create Actor", menuName = "Create Actor")]

//The purpose of this scriptable object is to hold general values for each of the gaem objects it is given to
public class SOActorModel : ScriptableObject
{
    //The name of the actor
    public string actorName;
    //Designer internal notes
    public string description;
    //How many time the actor can get hit before dying
    public int health;
    //Movement speed of the actor
    public int speed;
    //Rotation speed of the actor 
    public int rotationSpeed;
    //Jumping force of the actor 
    public int jumpingForce;

    public bool isImmune;
    //Place the actor prefab here
    public GameObject actor;

}
