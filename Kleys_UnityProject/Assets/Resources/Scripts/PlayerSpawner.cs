using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    //The actorModel contains values for player (stored into a Scriptable Object named actorMode
    SOActorModel actorModel;

    //The player holds a reference to the player once it has been created from the method CreatePlayer
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        //Go and look for the Scriptable Object named Player
        if(Resources.Load("Scripts/ScriptableObject/Player"))
        {
            //1) Instantiates the player ScriptableObject asset and stores it in the actorModel variable of type SOActorModel (our Scriptable Object).
            actorModel = Object.Instantiate(Resources.Load("Scripts/ScriptableObject/Player")) as SOActorModel;

            //2) Instantiate a game object that refers to our ScriptableObject that holds the game object called actor in the game variable named player (it takes a reference to the actual model).
            player = GameObject.Instantiate(actorModel.actor) as GameObject;

            //3) Apply the ScriptableObject asset to the player method called ActorStats that exists in the Player componentscript
            if(player.gameObject.GetComponent<Player>())
            {
                player.GetComponent<Player>().ActorStats(actorModel);
                SetPlayer();
            }
            else
            {
                Debug.Log("The class Player has not been attached to the Game Object, please attach it manually to the relative prefab");
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }

    void SetPlayer()
    {
        //The folloing code will set the player in the correct position at the start of the level 

        //1) Make leonard game object a child of the Leonard game object in the Hierarchy window so we can easily find it 
        player.transform.SetParent(this.transform);

        //2) Reset the position
        player.transform.position = this.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
