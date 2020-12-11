using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float verticalOffset;
    public float lookAheadDstX;
    public float lookSmoothTimeX;
    public float verticalSmoothTime;
    public Vector2 focusAreaSize;

    FocusArea focusArea;

    float currentLookAheadX;
    float targetLookAheadX;
    float lookAheadDirX;
    float smoothLookVelocityX;
    float smoothVelocityY;

    bool lookAheadStopped;

    Transform player;
    Collider col;
    bool is3D = false;

    float transitionSpeed = 2.3f;


    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnChangeDimension>(GetDimensions);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnChangeDimension>(GetDimensions);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        //focusArea = new FocusArea(col.collider.bounds, focusAreaSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CameraStartPositionIn3D()
    {
        //calculate where the camera chould be in 3D space

    }

    void CameraStartPositionIn2D()
    {
        //calculate where the camera should be in 2D space

    }



    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(focusArea.centre, focusAreaSize);
    }

    struct FocusArea
    {
        public Vector2 centre;
        public Vector2 velocity;
        float left, right;
        float top, bottom;


        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            velocity = Vector2.zero;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
        }

        public void Update(Bounds targetBounds)
        {
            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;

            float shiftY = 0;
            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            top += shiftY;
            bottom += shiftY;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }


    public void GetDimensions(OnChangeDimension dimension)
    {
        if (dimension.Dimension == "State2D")
        {
            is3D = false;
            CameraStartPositionIn2D();
        }
        else if (dimension.Dimension == "State3D")
        {
            is3D = true;
            CameraStartPositionIn3D();
        }
        else
        {
            Debug.Log("other State");
        }

    }

}
