/*Not sure what events to call yet but these seemed basic*/


using System;
using UnityEngine;

public class Events { }

public class Event { }

public class OnTitleEnable : Event { }
public class OnTitleDisable : Event { }
public class OnOptionEnable : Event { }
public class OnOptionDisable : Event { }
public class OnPauseEvent : Event{}
public class UnPauseEvent : Event{}





public class OnButtonSelect : Event{}
public class OnVirtHelmData : Event
{
    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float XPosition { get { return xPosition; } }
    public float YPosition { get { return yPosition; } }
    public float ZPosition { get { return zPosition; } }

    public OnVirtHelmData(float xPosition, float yPosition, float zPosition)
    {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.zPosition = zPosition;
    }

}


public class KareemEvent : Event{}

public class OnhitMetal : Event{}

public class OnChangeDimension : Event
{
    private string dimension;

    public string Dimension { get { return dimension; } }
    public OnChangeDimension(string dimension)
    {
        this.dimension = dimension;
    }
}


public class OnInteraction : Event
{
    //we can create a bunch of different constructors for what type of object is being interacted with
}


