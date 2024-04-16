using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgetUI : MonoBehaviour
{
    public GameObject upArr;
    public GameObject downArr;
    public GameObject leftArr;
    public GameObject rightArr;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                BegoneUI(leftArr);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                BegoneUI(rightArr);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                BegoneUI(upArr);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                BegoneUI(downArr);
            }
        }
    }

    void BegoneUI(GameObject arrow)
    {
        if (arrow != null)
        {
            arrow.gameObject.SetActive(false);
        }
    }
}
