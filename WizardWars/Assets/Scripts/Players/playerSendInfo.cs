using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class playerSendInfo : Photon.MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        //isMine = the current client only
        if( photonView.isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        bool RMB = Input.GetMouseButtonDown(1);

        if (RMB)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.Log("clicked!" + ray); //position in game

            //Physics.Raycast(ray, out hit);    //transform ray into raycasthit(which object it collided)
            //Debug.Log(hit.transform.tag);
            //if (hit.transform.tag == "Ground")
            {
                //Debug.Log(hit.point);
                this.GetComponent<PhotonView>().RPC("RecievedMove", PhotonTargets.All, ray.origin);
            }
        }

    }
}
