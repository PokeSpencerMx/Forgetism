using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Music : MonoBehaviour
{

    private static FMOD.Studio.EventInstance Music; //An event instance variable.
    public GameObject F2_Door;  //A reference which we'll use to reference the goal, and through that we'll get the goals co-ordinates.
    private static FMOD.Studio.EventInstance Music2;

    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu_music/Menu_Music");
        Music.start();
        Music.release();
    }

    public void Music_Change()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu_music/Menu_Music");
        Music2 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Level_Music/Level_Select");
        var musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        musicBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music2.start();

    }
}
