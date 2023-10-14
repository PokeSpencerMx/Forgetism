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
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Next scene");
        Debug.Log("GameObject1 collided with " + col.name);
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
