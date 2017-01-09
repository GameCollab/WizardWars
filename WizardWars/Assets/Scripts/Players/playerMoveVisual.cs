using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveVisual : Photon.MonoBehaviour {

    Vector3 newposition;
    public float speed;
    public float walkRange;

    public GameObject graphics;

    void Start()
    {
        newposition = this.transform.position;

        if(photonView.isMine)
        {
            this.gameObject.GetComponent<CameraManager>().OnStartFollowing();
        }

    }


    void Update()
    {
        if (Vector3.Distance(newposition, this.transform.position) > walkRange)
        {
            //MoveTowards = move in a straight line towards newposition
            this.transform.position = Vector3.MoveTowards(this.transform.position, newposition, speed * Time.deltaTime);

            //Sprite Direction here:
            //Quaternion transRot = Quaternion.LookRotation(newposition - this.transform.position, Vector3.up);
            //graphics.transform.rotation = Quaternion.Slerp(transRot, graphics.transform.rotation, 0.5f);
        }
    }

    [PunRPC]
    public void RecievedMove(Vector3 movePos)
    {
        newposition = new Vector3(movePos.x,movePos.y,0);
    }
}
