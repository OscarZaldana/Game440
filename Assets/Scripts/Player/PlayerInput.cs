using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;
    Ray2D pC;

    bool is3D = false;
    bool is2D = false;

    KeyCode left2D = KeyCode.LeftArrow;
    KeyCode right2D = KeyCode.RightArrow;
    KeyCode up2D = KeyCode.UpArrow;
    KeyCode down2D = KeyCode.DownArrow;
    KeyCode a2D = KeyCode.A;
    KeyCode d2D = KeyCode.D;
    KeyCode w2D = KeyCode.W;
    KeyCode s2D = KeyCode.S;
    KeyCode lShift2D = KeyCode.LeftShift;
    KeyCode tab2D = KeyCode.Tab;
    KeyCode space2D = KeyCode.Space;



    KeyCode left3D = KeyCode.LeftArrow;
    KeyCode right3D = KeyCode.RightArrow;
    KeyCode up3D = KeyCode.UpArrow;
    KeyCode down3D = KeyCode.DownArrow;
    KeyCode a3D = KeyCode.A;
    KeyCode d3D = KeyCode.D;
    KeyCode w3D = KeyCode.W;
    KeyCode s3D = KeyCode.S;



    KeyCode jump;

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
        player = GetComponent<Player>();
        pC = GetComponent<Ray2D>();
    }

    void Update()
    {
        if(is2D == true)
        {
            //    //Left walking
            //    if (Input.GetKeyDown(left2D) || Input.GetKeyDown(a2D))
            //    {
            //        pC.MoveDirection(-1);
            //        player.walk2D = true;
            //    }
            //    //Right Walking
            //    if (Input.GetKeyDown(right2D) || Input.GetKeyDown(d2D))
            //    {
            //        pC.MoveDirection(1);
            //        player.walk2D = true;
            //    }
            //    //jumping
            //    if (Input.GetKeyDown(up2D) || Input.GetKeyDown(w2D))
            //    {
            //        pC.VerticalDirection(1);
            //        player.jump = true;
            //    }
            //    //crotching
            //    if (Input.GetKeyDown(down2D) || Input.GetKeyDown(s2D))
            //    {
            //        pC.VerticalDirection(-1);
            //        player.crotch = true;
            //    }
            //    //Stop Walking Left
            //    if (Input.GetKeyUp(left2D) || Input.GetKeyUp(a2D))
            //    {

            //        player.walk2D = false;
            //    }
            //    //Stop Walking Right
            //    if (Input.GetKeyUp(right2D) || Input.GetKeyUp(d2D))
            //    {

            //        player.walk2D = false;
            //    }
            //    //stop jumping
            //    if (Input.GetKeyUp(up2D) || Input.GetKeyUp(w2D))
            //    {

            //        player.jump = false;
            //    }
            //    //Stop Walking Right
            //    if (Input.GetKeyUp(down2D) || Input.GetKeyUp(s2D))
            //    {

            //        player.crotch = false;
            //    }
            if (Input.GetKeyDown(KeyCode.W))
            {
                jump = KeyCode.W;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = KeyCode.Space;
            }

            Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), player.transform.position.z);
            player.SetDirectionalInput(directionalInput);

            if (Input.GetKeyDown(jump))
            {
                player.jumping = true;
                player.OnJumpInputDown();
            }
            if (Input.GetKeyUp(jump))
            {
                player.jumping = false;
                player.OnJumpInputUp();
            }


        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //if(is3D == true)
        //{

        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





        //if (Input.GetKeyDown(KeyCode.W))
        //{


        //    //jump = KeyCode.W;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jump = KeyCode.Space;
        //}

    }

    public void GetDimensions(OnChangeDimension dimension)
    {
        if (dimension.Dimension == "State2D")
        {
            is2D = true;
            is3D = false;
        }
        else if (dimension.Dimension == "State3D")
        {
            is3D = true;
            is2D = false;
        }
        else
        {
            is2D = false;
            is3D = false;
        }

    }

}



