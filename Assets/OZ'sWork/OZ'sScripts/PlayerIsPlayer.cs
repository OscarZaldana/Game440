using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsPlayer : MonoBehaviour
{
    VirtualHelmet vh;
    RaycastHit hit;


    float posZ;
    float posY;
    float posX;

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnVirtHelmData>(GetDimensions);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnVirtHelmData>(GetDimensions);
    }

    public void GetDimensions(OnVirtHelmData vr)
    {
        this.posX = vr.XPosition;
        this.posY = vr.YPosition;
        this.posZ = vr.ZPosition;
    }

    void updatePosition()
    {
        transform.position = new Vector3(posX, posY, posZ);
    }


    // Update is called once per frame
    void Update()
    {
        
        Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(gameObject.transform.position, fwd * 2, Color.red);
        Physics.Raycast(gameObject.transform.position, fwd, out hit, 2);





        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.collider != null && hit.collider.tag == "VirtualHelmet")
            {
                this.vh = hit.collider.GetComponent<VirtualHelmet>();
                EventHandler.Instance.Broadcast(new OnVirtHelmData(hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z-1));
                updatePosition();
                vh.ChangeDimension();
            }
        }
    }
}
