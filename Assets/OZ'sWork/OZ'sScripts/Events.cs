/*Not sure what events to call yet but these seemed basic*/


using System;
using UnityEngine;

public class Events { }

public class Event { }

public class ExampleEvent : Event { }

public class PauseEvent : Event
{
}
public class UnPauseEvent : Event
{

}
public class OnButtonSelect : Event
{
}

public class OnHit : Event { }

public class On3DState : Event
{
    public On3DState(Camera cam, GameObject target)
    {
        float distance3DOfZ = -2f;
        float distance3DOfY = 1f;
        float distance3DOfX = 1f;


        cam.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        cam.transform.position = new Vector3(target.transform.position.x + distance3DOfX, target.transform.position.y + distance3DOfY, target.transform.position.z + distance3DOfZ);
        cam.orthographic = false;


    }

}

