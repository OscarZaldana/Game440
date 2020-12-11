using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    public LayerMask collisionMask;

    public const float skinWidth = .015f;
    public const float dstBetweenRays = .05f;
    [HideInInspector]
    public int horizontalRayCount;
    [HideInInspector]
    public int verticalRayCount;
    [HideInInspector]
    public int zedRayCount;

    [HideInInspector]
    public float horizontalRaySpacing;
    [HideInInspector]
    public float verticalRaySpacing;
    [HideInInspector]
    public float zedRaySpacing;

    [HideInInspector]
    public BoxCollider collider;
    public RaycastOrigins raycastOrigins;

    public virtual void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    public void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.leftCenter = new Vector3(bounds.min.x, bounds.center.y, bounds.center.z);
        raycastOrigins.leftTopLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
        raycastOrigins.leftTopRight = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
        raycastOrigins.leftBottomLeft = new Vector3(bounds.min.x, bounds.min.y, bounds.min.z);
        raycastOrigins.leftBottomRight = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);

        raycastOrigins.rightCenter = new Vector3(bounds.max.x, bounds.center.y, bounds.center.z);
        raycastOrigins.rightTopLeft = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
        raycastOrigins.rightTopRight = new Vector3(bounds.max.x, bounds.max.y, bounds.max.z);
        raycastOrigins.rightBottomLeft = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
        raycastOrigins.rightBottomRight = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);

        raycastOrigins.topCenter = new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
        raycastOrigins.topLeftForward = new Vector3(bounds.max.x, bounds.max.y, bounds.max.z);
        raycastOrigins.topLeftBack = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
        raycastOrigins.toprightForward = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
        raycastOrigins.topRightBack = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);

        raycastOrigins.forwardCenter = new Vector3(bounds.center.x, bounds.center.y, bounds.max.z);
    }


    public void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;
        float boundsDepth = bounds.size.z;

        horizontalRayCount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);
        zedRayCount = Mathf.RoundToInt(boundsDepth / dstBetweenRays);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
        zedRaySpacing = bounds.size.z / (zedRayCount - 1);

    }


    public struct RaycastOrigins
    {
        public Vector3 leftCenter, rightCenter;
        public Vector3 leftTopLeft, leftTopRight;
        public Vector3 leftBottomLeft, leftBottomRight;
        public Vector3 rightTopLeft, rightTopRight;
        public Vector3 rightBottomLeft, rightBottomRight;
        public Vector3 topLeftForward, topLeftBack, topCenter, toprightForward, topRightBack;

        public Vector3 forwardCenter;
    };
}