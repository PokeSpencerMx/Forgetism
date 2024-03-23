using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string nextLevelName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Quitting the Level
        if (Input.GetKeyDown(KeyCode.Q)) // If player hits the Q Key
        {
            //Loads the scene called nextLevelName, which is the level select screen of this world.
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Next scene");
        Debug.Log("GameObject1 collided with " + col.name);
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }

    public void LevelSelect()
    {
        Debug.Log(nextLevelName);
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
