using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    SpriteRenderer s_rend;
    public GameObject doors_map;

    // Start is called before the first frame update
    void Start()
    {
        Color offColor = Color.red;
        Color onColor = Color.green;
        s_rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D()
    {
        //Debug.Log("Hello world.");
        // s_rend.color = Color.green;
        OpenTheDoor();
        


    }

    void OnTriggerExit2D()
    {
        // s_rend.color = Color.red;
        CloseTheDoor();
        
        
    }

    public void OpenTheDoor()
    {
        // Debug.Log("Door is open");
        if (doors_map != null)
        {
            doors_map.gameObject.SetActive(false);
        }
        
        
    }

    public void CloseTheDoor()
    {
        // Debug.Log("Door is closed");
        doors_map.gameObject.SetActive(true);

    }

}
