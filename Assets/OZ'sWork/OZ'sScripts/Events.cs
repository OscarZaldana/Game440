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
        this.xPosition = xPosition;
        this.xPosition = xPosition;
    }

}


public class OnChangeDimension : Event
{
    private string dimension;

    public string Dimension { get { return dimension; } }
    public OnChangeDimension(string dimension)
    {
        this.dimension = dimension;
    }

    

}

