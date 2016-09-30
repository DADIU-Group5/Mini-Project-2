using UnityEngine;
using System.Collections;
using Mini2.Utils;

/// <summary>
/// Used to play sounds (events) from Wwise
/// </summary>
public class AudioMaster : Singleton<AudioMaster> {

    uint bankID;

	// Loads the soundbank containing all necessary sounds (events)
	void Start()
    {
        AkSoundEngine.LoadBank("Soundbank1", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
        PlayEvent("musicPlay");
	}

    public void PlayEvent(string eventName)
    {
        AkSoundEngine.PostEvent(eventName, gameObject);
    }

    public void PlayEvent(string eventName, float fadein)
    {
        AkSoundEngine.PostEvent(eventName, gameObject);
        PauseEvent(eventName, 0);
        ResumeEvent(eventName, fadein);
    }

    public void StopEvent(string eventName, float fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(eventName);
        int fadeoutMs = (int)fadeout * 1000;
        AkSoundEngine.ExecuteActionOnEvent(
            eventID, 
            AkActionOnEventType.AkActionOnEventType_Stop, 
            gameObject, fadeoutMs, 
            AkCurveInterpolation.
            AkCurveInterpolation_Sine);
    }

    public void PauseEvent(string eventName, float fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(eventName);
        int fadeoutMs = (int)fadeout * 1000;
        AkSoundEngine.ExecuteActionOnEvent(
            eventID, 
            AkActionOnEventType.AkActionOnEventType_Pause, 
            gameObject, 
            fadeoutMs, 
            AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

    public void ResumeEvent(string eventName, float fadein)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(eventName);
        int fadeinMs = (int)fadein * 1000;
        AkSoundEngine.ExecuteActionOnEvent(
            eventID, 
            AkActionOnEventType.AkActionOnEventType_Resume, 
            gameObject, 
            fadeinMs, 
            AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
