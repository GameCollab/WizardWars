using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public int maxLife;
    public int curLife;
    public int moveSpeed;

    public object[] spells;

    //increased damage, area of effect, duration and projectile speed are % values
    public int incFireDmg;
    public int incFireAoE;
    public int incFireDuration;
    public int incFireProjSpeed;

    public int incLightningDmg;
    public int incLightningAoE;
    public int incLightningDuration;
    public int incLightningProjSpeed;

    public int incWaterDmg;
    public int incWaterAoE;
    public int incWaterDuration;
    public int incWaterProjSpeed;

    public int incGravityDmg;
    public int incGravityAoE;
    public int incGravityDuration;
    public int incGravityProjSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
