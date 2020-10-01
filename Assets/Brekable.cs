using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brekable : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
