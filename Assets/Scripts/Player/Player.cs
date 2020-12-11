using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*-------------------------------------------------PlayerVariables----------------------------------------*/
    public Vector3 directionalInput;



    float moveSpeed = 10;

    bool is3D = false;

    /*-------------------------------------------------2D Attributes----------------------------------------*/






    public bool walk2D = false;
    public bool jump = false;
    public bool crotch = false;

    /*-------------------------------------------------3D Attributes----------------------------------------*/





    /*-------------------------------------------------In Game Section----------------------------------------*/

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnChangeDimension>(GetDimensions);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnChangeDimension>(GetDimensions);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetDirectionalInput(Vector3 input)
    {
        directionalInput = input;
    }


    /*-------------------------------------------------2D Section----------------------------------------*/

    public void Move2D()
    {
        if(walk2D == true)
        {

        }
    }








    /*-------------------------------------------------3D Section----------------------------------------*/







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
        else
        {
            Debug.Log("other State");
        }

    }

}



























//public float maxJumpHeight = 4;
//public float minJumpHeight = 1;
//public float timeToJumpApex = .4f;
//float accelerationTimeAirborne = .2f;
//float accelerationTimeGrounded = .1f;
//float moveSpeed = 10;

//public Vector2 wallJumpClimb;
//public Vector2 wallJumpOff;
//public Vector2 wallLeap;

//public float wallSlideSpeedMax = 3;
//public float wallStickTime = .25f;
//float timeToWallUnstick;

//float gravity;
//float maxJumpVelocity;
//float minJumpVelocity;
//[SerializeField]
//float dashVelocity = 5;
//[SerializeField]
//float extraJumps;
//public float extraDash = 1;
//[SerializeField]
//float runSpeed;
//public float jumpsMade;
//public float dashesMade;
//public Vector3 velocity;
//float velocityXSmoothing;


//PlayerController controller;

//RaycastHit hit;

//public Vector3 directionalInput;
////public bool wallSliding;
////int wallDirX;
////public bool dashing = false;
////public bool jumping = false;
//Collider col;
//BoxCollider colider;
//public Vector3 forwardCenter;
////Bounds bounds = colider.bounds;

//bool is3D = false;

//private void OnEnable()
//{
//    EventHandler.Instance.Subscribe<OnChangeDimension>(GetDimensions);
//}

//private void OnDisable()
//{
//    EventHandler.Instance.Unsubscribe<OnChangeDimension>(GetDimensions);
//}


//void Start()
//{
//    col = GetComponent<Collider>();
//    colider = GetComponent<BoxCollider>();
//    controller = GetComponent<PlayerController>();
//    gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
//    maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
//    minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
//}

//private void Update()
//{
//    if (is3D == false)
//    {
//        WalkOrRun2D();
//        CalculateVelocity2D();
//    }
//    else if (is3D == true)
//    {
//        controller.Horizantal3DCollisions();
//    }
//}


//public void SetDirectionalInput(Vector3 input)
//{
//    directionalInput = input;
//}


//public void WalkOrRun2D()
//{
//    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
//    {
//        controller.Move2D(velocity * Time.deltaTime * runSpeed, directionalInput);
//    }
//    else
//    {
//        controller.Move2D(velocity * Time.deltaTime, directionalInput);
//    }
//}

//void CalculateVelocity2D()
//{
//    float targetVelocityX = directionalInput.x * moveSpeed;
//    velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
//    velocity.y += 0; //gravity * Time.deltaTime;
//}

//public void WalkOrRun3D()
//{
//    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
//    {
//        controller.Move3D(velocity * Time.deltaTime * runSpeed, directionalInput);
//    }
//    else
//    {
//        controller.Move3D(velocity * Time.deltaTime, directionalInput);
//    }
//}

//void CalculateVelocity3D()
//{
//    float targetVelocityX = directionalInput.x * moveSpeed;
//    velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
//    velocity.y += 0; //gravity * Time.deltaTime;
//}


//public void GetDimensions(OnChangeDimension dimension)
//{
//    if (dimension.Dimension == "State2D")
//    {
//        is3D = false;
//    }
//    else if (dimension.Dimension == "State3D")
//    {
//        is3D = true;
//    }
//    else
//    {
//        Debug.Log("other State");
//    }

//}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//void Update()
//{
//    if (dashing)
//    {
//        StartCoroutine("TurnDashFalse");
//    }

//    CalculateVelocity();
//    HandleWallSliding();

//    WalkOrRun();

//    if (controller.collisions.above || controller.collisions.below)
//    {

//        if (controller.collisions.slidingDownMaxSlope)
//        {
//            velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
//        }
//        else
//        {
//            velocity.y = 0;
//        }
//    }

//    if (controller.collisions.below)
//    {
//        dashesMade = 0;
//        jumpsMade = 0;
//    }
//    if (controller.collisions.left || controller.collisions.right)
//    {
//        jumpsMade = 0;
//        dashesMade = 0;
//    }
//}

//public void SetDirectionalInput(Vector2 input)
//{
//    directionalInput = input;
//}

//public void WalkOrRun()
//{
//    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
//    {
//        controller.Move(velocity * Time.deltaTime * runSpeed, directionalInput);
//    }
//    else
//    {
//        controller.Move(velocity * Time.deltaTime, directionalInput);
//    }
//}

//public void OnJumpInputDown()
//{
//    jumpsMade++;
//    if (wallSliding)
//    {
//        jumpsMade = 0;
//        if (wallDirX == directionalInput.x)
//        {
//            velocity.x = -wallDirX * wallJumpClimb.x;
//            velocity.y = wallJumpClimb.y;
//        }
//        else if (directionalInput.x == 0)
//        {
//            velocity.x = -wallDirX * wallJumpOff.x;
//            velocity.y = wallJumpOff.y;
//        }
//        else
//        {
//            velocity.x = -wallDirX * wallLeap.x;
//            velocity.y = wallLeap.y;
//        }
//    }
//    if (controller.collisions.below)
//    {
//        jumpsMade = 0;
//        if (controller.collisions.slidingDownMaxSlope)
//        {
//            if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
//            { // not jumping against max slope
//                velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
//                velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
//            }
//        }
//        else
//        {
//            velocity.y = maxJumpVelocity;
//        }
//    }

//    if (!controller.collisions.below && jumpsMade <= extraJumps)
//    {
//        velocity.y = maxJumpVelocity;
//    }
//}

//public void OnJumpInputUp()
//{
//    if (velocity.y > minJumpVelocity)
//    {
//        velocity.y = minJumpVelocity;
//    }
//}


//void HandleWallSliding()
//{
//    wallDirX = (controller.collisions.left) ? -1 : 1;
//    wallSliding = false;
//    if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
//    {
//        wallSliding = true;

//        if (velocity.y < -wallSlideSpeedMax)
//        {
//            velocity.y = -wallSlideSpeedMax;
//        }

//        if (timeToWallUnstick > 0)
//        {
//            velocityXSmoothing = 0;
//            velocity.x = 0;

//            if (directionalInput.x != wallDirX && directionalInput.x != 0)
//            {
//                timeToWallUnstick -= Time.deltaTime;
//            }
//            else
//            {
//                timeToWallUnstick = wallStickTime;
//            }
//        }
//        else
//        {
//            timeToWallUnstick = wallStickTime;
//        }

//    }
//}

//public void Dashing()
//{
//    if (!wallSliding)
//    {
//        if (dashesMade <= extraDash)
//        {
//            dashesMade++;
//            velocity.y = 0;
//            velocity.x *= dashVelocity;
//            dashing = true;
//        }
//    }
//}

//void CalculateVelocity()
//{
//    float targetVelocityX = directionalInput.x * moveSpeed;
//    velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
//    velocity.y += 0; //gravity * Time.deltaTime;
//}

//IEnumerator TurnDashFalse()
//{
//    yield return new WaitForSeconds(0.5f);

//    dashing = false;
//}