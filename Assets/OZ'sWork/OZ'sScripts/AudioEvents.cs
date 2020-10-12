using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{

    static int haha = 0;

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnChangeDimension>(DimensionSoundChange);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnChangeDimension>(DimensionSoundChange);
    }


    public void DimensionSoundChange(OnChangeDimension sound)
    {
        //if (sound.Dimension == "State3D")
        //{
        //    haha++;
        //    Debug.Log(haha);
        //    if (haha > 3)
        //    {
        //        Debug.Log("funny sound");
        //    }
        //}
    }
}
