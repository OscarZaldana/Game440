using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;

    KeyCode jump;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = KeyCode.W;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = KeyCode.Space;
        }

        Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), transform.position.y, Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        //if (Input.GetKeyDown(jump))
        //{
        //    player.jumping = true;
        //    player.OnJumpInputDown();
        //}
        //if (Input.GetKeyUp(jump))
        //{
        //    player.jumping = false;
        //    player.OnJumpInputUp();
        //}
        //if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        //{
        //    player.Dashing();
        //}
    }
}
