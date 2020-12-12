using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Ray2D target;
    public Transform player;
    public float verticalOffset;
    public float lookAheadDstX;
    public float lookSmoothTimeX;
    public float verticalSmoothTime;
    public float smoothspeed = 0.125f;
    public Vector3 focusAreaSize;
    FocusArea focusArea;

    float currentLookAheadX;
    float targetLookAheadX;
    float lookAheadDirX;
    float smoothLookVelocityX;
    float smoothVelocityY;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float y = 0.0f;
    private float pitch = 0.0f;

    bool lookAheadStopped;
    bool is3D = false;

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnChangeDimension>(GetDimensions);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnChangeDimension>(GetDimensions);
    }

    void Start()
    {
        focusArea = new FocusArea(target.collider.bounds, focusAreaSize);
    }

    void LateUpdate()
    {
        if(is3D == false)
        {
            focusArea.Update(target.collider.bounds);

            Vector3 focusPosition = focusArea.centre + Vector3.up * verticalOffset;

            if (focusArea.velocity.x != 0)
            {
                lookAheadDirX = Mathf.Sign(focusArea.velocity.x);
                if (Mathf.Sign(target.playerInput.x) == Mathf.Sign(focusArea.velocity.x) && target.playerInput.x != 0)
                {
                    lookAheadStopped = false;
                    targetLookAheadX = lookAheadDirX * lookAheadDstX;
                }
                else
                {
                    if (!lookAheadStopped)
                    {
                        lookAheadStopped = true;
                        targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
                    }
                }
            }


            currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

            focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
            focusPosition += Vector3.right * currentLookAheadX;
           focusPosition.z = transform.position.z;
            transform.position = (Vector3)focusPosition;
        }

        if(is3D == true)
        {
            transform.position = player.transform.position;
            updateCam();
        }

    }

    public void updateCam()
    {
        y -= speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, y, 0.0f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(focusArea.centre, focusAreaSize);
    }

    struct FocusArea
    {
        public Vector3 centre;
        public Vector3 velocity;
        float left, right;
        float top, bottom;


        public FocusArea(Bounds targetBounds, Vector3 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            velocity = Vector3.zero;
            centre = new Vector3((left + right) / 2, (top + bottom) / 2);
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
            centre = new Vector3((left + right) / 2, (top + bottom) / 2, 1);
            velocity = new Vector3(shiftX, shiftY, 1);
        }
    }

    public void GetDimensions(OnChangeDimension dimension)
    {
        if (dimension.Dimension == "State2D")
        {
            is3D = false;
        }
        else if (dimension.Dimension == "State3D")
        {
            is3D = true;
        }
    }
}
