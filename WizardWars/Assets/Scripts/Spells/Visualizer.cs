using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour {
    public Animator _animator;

    public AudioSource _audio;

    public Collider _collider;

    public string _toIdle;
    public string _toActive;
    public string _toDeath;

    public AudioClip _idleClip;
    public AudioClip _activeClip;
    public AudioClip _deathClip;

    public Enums.Visuals.State _state;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Idle()
    {

    }

    public void Active()
    {

    }

    public void Die()
    {

    }
}
