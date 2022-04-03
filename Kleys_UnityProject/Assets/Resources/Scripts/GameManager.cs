using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Singleton Design Pattern
 * 
 * A singleton pattern gives us global access to code that can be obtained nearly at a point in our game 
 * In Unity the GameManager is a script that is always accessible, no matter what scene we are in 
 * Manager scripts (like the GameManager) have a global access to all other scripts in the game 
 * Managers gives an understanding on what is going on in the game 
 * The Manager object is present in the Hierarchy window 
 * To make it so that the object and script is not beign wiped a Singleton design pattern is used 
 * The design pattern makes it so that there is only one GameManager script --> this is where the design pattern takes its name --> SINGLEton 
*/
public class GameManager : MonoBehaviour
{
    //static means that there will be only be one type of game manager 
    static GameManager instance; 
    public static int playerLifes = 3;
    //public static int currentScene;
    //public static int gameLeveleScene = 3;

    public static GameManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        //Check and assign our instance variable with the GameManager class when the script begins with the Awake function
        CheckGamaManagerIsInTheScene();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckGamaManagerIsInTheScene()
    {
        //The if statement avoid any possible duplicate of the class
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
        /*
         * thuis makes sure that the game object holding our GameManager class is not going to be destroyed if the scene changes 
         * So if the player dies and we go to the gameOver scene the GameManager is not wiped out and holds the main core methods to run the game 
        */
    }

    //This method is called by the Player script when a life is lost 
    public void LifeLost()
    {
        playerLifes--;
        if (playerLifes > 0)
        {
            Debug.Log("Lives left: " + playerLifes);
        }
        else
        {
            //If the player does not have anymore lifes left the number of lifes is restored and the GameOver method of the class SceneManager is called 
            playerLifes = 3;
            //GetComponent<SceneManger>().GameOver; 
            Debug.Log("DEAD");
        }

    }
}
