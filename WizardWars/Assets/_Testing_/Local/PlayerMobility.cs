using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour, IMovable {
    [HideInInspector]
    public bool _playerIsMoving;
    [HideInInspector]
    public bool _playerisPushed;

    Rigidbody _rigidbody;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
        {
            Move();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
        if(_rigidbody.velocity.x == 0 || _rigidbody.velocity.y == 0)
        {
            _playerIsMoving = false;
        }
	}

    public void Move()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 mouse = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (this.transform.position - mouse).normalized;
        _rigidbody.velocity = direction * GetComponent<PlayerStats>()._attributes.Speed;
        _playerIsMoving = true;
    }

    public void Push(Vector3 force)
    {
        if (CanBePushed())
        {
            _rigidbody.AddForce(force);
        }
    }

    public void Teleport(Vector3 position)
    {
        if (CanTeleport())
        {
            this.transform.position = position;
        }
    }

    public bool CanMove()
    {
        return true; //Currently there is nothing preventing the player from moving, except obviously dying
    }

    public bool CanTeleport()
    {
        return true; //See above
    }

    public bool CanBePushed()
    {
        return true; //See above
    }


}
