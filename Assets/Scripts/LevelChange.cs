using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string nextLevelName;
    private static FMOD.Studio.EventInstance Music; //An event instance variable.
    private static FMOD.Studio.EventInstance Music2;
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
    public void Music_Change()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu_music/Menu_Music");
        Music2 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Level_Music/Level_Select");
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music2.start();

    }
}
