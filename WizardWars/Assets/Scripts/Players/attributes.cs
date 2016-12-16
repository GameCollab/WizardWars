using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attributes : MonoBehaviour {

    private int maxLife;
    private int curLife;
    private int numberOfProj;

    //**********% VALUES***********
    private int incFireDmg;
    private int incFireAoE;
    private int incFireDur;
    private int incFireProjSpeed;

    private int incLightDmg;
    private int incLightAoE;
    private int incLightDur;
    private int incLightProjSpeed;

    private int incWaterDmg;
    private int incWaterAoE;
    private int incWaterDur;
    private int incWaterProjSpeed;

    private int incGravityDmg;
    private int incGravityAoE;
    private int incGravityDur;
    private int incGravityProjSpeed;

    private int chancetoFreeze;
    private int knockbackRes;
    private int cooldownRed;
    private int incMoveSpeed;
    //******************************

    public int this[string i]
    {
        get
        {
            switch (i)
            {
                case "maxLife":
                    return maxLife;
                case "curLife":
                    return curLife;
                case "numberOfProj":
                    return numberOfProj;
                case "incFireDmg":
                    return incFireDmg;
                case "incFireAoE":
                    return incFireAoE;
                case "incFireDur":
                    return incFireDur;
                case "incFireProjSpeed":
                    return incFireProjSpeed;
                case "incLightDmg":
                    return incLightDmg;
                case "incLightAoE":
                    return incLightAoE;
                case "incLightDur":
                    return incLightDur;
                case "incLightProjSpeed":
                    return incLightProjSpeed;
                case "incWaterDmg":
                    return incWaterDmg;
                case "incWaterAoE":
                    return incWaterAoE;
                case "incWaterDur":
                    return incWaterDur;
                case "incWaterProjSpeed":
                    return incWaterProjSpeed;
                case "incGravityDmg":
                    return incGravityDmg;
                case "incGravityAoE":
                    return incGravityAoE;
                case "incGravityDur":
                    return incGravityDur;
                case "incGravityProjSpeed":
                    return incGravityProjSpeed;
                case "chanceToFreeze":
                    return chancetoFreeze;
                case "knockbackRes":
                    return knockbackRes;
                case "cooldownRed":
                    return cooldownRed;
                case "incMoveSpeed":
                    return incMoveSpeed;
                default:
                    //not a valid attribute
                    return -1;
            }
        }
        set
        {
            switch (i)
            {
                case "maxLife":
                    maxLife = value;
                    break;
                case "curLife":
                    curLife = value;
                    break;
                case "numberOfProj":
                    numberOfProj = value;
                    break;
                case "incFireDmg":
                    incFireDmg = value;
                    break;
                case "incFireAoE":
                    incFireAoE = value;
                    break;
                case "incFireDur":
                    incFireDur = value;
                    break;
                case "incFireProjSpeed":
                    incFireProjSpeed = value;
                    break;
                case "incLightDmg":
                    incLightDmg = value;
                    break;
                case "incLightAoE":
                    incLightAoE = value;
                    break;
                case "incLightDur":
                    incLightDur = value;
                    break;
                case "incLightProjSpeed":
                    incLightProjSpeed = value;
                    break;
                case "incWaterDmg":
                    incWaterDmg = value;
                    break;
                case "incWaterAoE":
                    incWaterAoE = value;
                    break;
                case "incWaterDur":
                    incWaterDur = value;
                    break;
                case "incWaterProjSpeed":
                    incWaterProjSpeed = value;
                    break;
                case "incGravityDmg":
                    incGravityDmg = value;
                    break;
                case "incGravityAoE":
                    incGravityAoE = value;
                    break;
                case "incGravityDur":
                    incGravityDur = value;
                    break;
                case "incGravityProjSpeed":
                    incGravityProjSpeed = value;
                    break;
                case "chanceToFreeze":
                    chancetoFreeze = value;
                    break;
                case "knockbackRes":
                    knockbackRes = value;
                    break;
                case "cooldownRed":
                    cooldownRed = value;
                    break;
                case "incMoveSpeed":
                    incMoveSpeed = value;
                    break;
                default:
                    //not a valid attribute
                    break;
            }
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // For testing stufffffffff
    void unitTest() {
        attributes aTest = new attributes();
        aTest["maxLife"] = 5;
        Debug.Log(aTest["maxLife"]);
    }
}
