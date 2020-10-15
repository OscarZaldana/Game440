using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{

    static int haha = 0;

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnVirtHelmData>(DimensionSoundChange);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnVirtHelmData>(DimensionSoundChange);
    }


    public void DimensionSoundChange(OnVirtHelmData sound)
    {
                //AudioManager.Instance.PlaySound("Help", 1f);
    }
}
