using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject receiver;

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			player.transform.position = new Vector3(receiver.transform.position.x, receiver.transform.position.y, 0);
			Debug.Log("hit");
		}
	}

}
