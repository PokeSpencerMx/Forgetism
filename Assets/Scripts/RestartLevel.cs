using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    Scene scene;
    // Scene nextLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);

        //nextLevel = SceneManager.GetSceneByBuildIndex()
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("Space");
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }
}
