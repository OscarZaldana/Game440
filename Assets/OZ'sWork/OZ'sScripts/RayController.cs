using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script is being used to effect the rays when they are created. Think of it as perameters for the rays and how you want it to project itself from 
 * the object calling it. Which ever object calls this script will then have a set of rays with a set length. 
 * Because this was made for 2D objects it is asking that the object that is calling this script have a 2DBoxCollider
 If you have objects with 3DBoxColliders and wish to use this script for both 2D and 3D then first get rid of the RequireComponent because it will cause the game to not run unless its requirments are met.
 To determine which type of collider the object has by creating a bool that you have access to and determine what you want the object to have and then create that component with addcomponent */




/*RayController is inhereting all of Monobeaviour's classes. This means we can use any components of unity because MonoBehaviour is their class based system*/
[RequireComponent(typeof(BoxCollider2D))]
public class RayController : MonoBehaviour
{
    /*LayerMask is a unity component that objects have that allow them to associat themself as a layer of some type.
     layers are used for cameras and raycasting because it is looking for what is being rendered. It can be good to use layers when you want things to not be rendered unless
     in a certain view point so that the computer doesn't slow down when there are two many objects.*/
    public LayerMask collisionMask;


    public const float skinWidth = .015f;
    const float dstBetweenRays = .25f;

    /*HideInInspector:  When we make something public it will show up in the inspector. If we dont
     want it to show up in the inspector because it just takes up space then we want to use [HideInInspector] 
     right above what ever we want it to hide*/
    [HideInInspector]
    public int horizontalRayCount;
    [HideInInspector]
    public int verticalRayCount;

    [HideInInspector]
    public float horizontalRaySpacing;
    [HideInInspector]
    public float verticalRaySpacing;


    /*This is creating a variable of type BoxCollider2D which is a component of unity. We use this to access the collider of what ever is calling this script*/
    [HideInInspector]
    public BoxCollider2D collider;

    /*call upon the struct that was created below so that other methods have access to it.*/
    public RaycastOrigins raycastOrigins;

    /*marking as virtual because other scripts call upon this class making this class the parent.
     Also making sure that we have the boxcollider of what ever is calling this script*/
    public virtual void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }


    /*Calculating rayspacing so that the rays know where to start on an object*/
    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    /*This is the method that will be called by other scripts*/
    public void UpdateRaycastOrigins()
    {
        /*Bounds is the bounds of the box and how big it is. The vector length of it.
         getting the length of the bounds of the object that is calling it*/
        Bounds bounds = collider.bounds;
        /*Expanding the bounds with a negative number to shrink the min and max starting position.
         This is so that the objects don't get weirdly stuck when they are right at the edge of each other*/
        bounds.Expand(skinWidth * -2);

        /*bounds.min and max are features of unity. It calculates the edges of the block for you.
         we are obtaining the top and right min and max of what ever object is calling it and setting it
         to the struct variables*/
        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        /*we need a number to calculate how many rays we want on each object*/
        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        /*This will calulate how many rays will appear and distance themself by the distBetweenRays
         The number is set to .25 meaning that I want an array at every 25% of this 1 block
         It rounds to the nearest int so that it knows I want 4 rays, otherwise we would get a percentage of a ray extra*/
        horizontalRayCount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);


        /*At this point we know we want 4 rays, so to space them apart we basicly are  subtracting by 1 because there is always 
         one less space inbetween things. Think about how there are 4 spaces inbetween your 5 fingers. and then dividing by the number to space them apart properly*/
        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    /*Create a struct for each of the object to collect there different bounds and make sure that we are affect the bounds of the
     different objects and not everything that has this script attached*/
    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    };
}
