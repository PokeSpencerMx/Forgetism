using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private bool unlocked; //Is this level selectable?
    public Image unlockImage;
    public GameObject[] stars;

    private void Update()
    {
        UpdateLevelImage();
    }

    private void UpdateLevelImage()
    {
        if(!unlocked)//If this level is locked...
        {
            unlockImage.gameObject.SetActive(true);
            
            stars[0].gameObject.SetActive(false);
            // for(int i=0; i < stars.length; i++)
            // {
            //     //...hide all star images.
            //     stars[i].gameObject.SetActive(true);
            // }
        }
        else //If this level is unlocked and playable...
        {
            unlockImage.gameObject.SetActive(false);
            stars[0].gameObject.SetActive(true);
            // for(int i=0; i < stars.length; i++)
            // {
            //     //...show all star images.
            //     stars[i].gameObject.SetActive(true);
            // }
        }
    }
}
