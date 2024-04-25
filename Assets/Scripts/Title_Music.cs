using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Music : MonoBehaviour
{

    public FMOD.Studio.EventInstance Music;
    



    void Start()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().EventInstance.Progress();
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu_music/Menu_Music");
        //Music.start();
        //Music.release();
    }

    public void Progress (float ProgressLevel)
    {
        Music.setParameterByName("Progress",ProgressLevel);
        Debug.Log(ProgressLevel);
       
    }
    private void OnDestroy()
    {
        //Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}


