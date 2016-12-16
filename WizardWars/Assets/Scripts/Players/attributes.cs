using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attributes : MonoBehaviour {

    //*********FLAT VALUES*********
    private int maxLife = 100;
    private int curLife = 100;
    private int numberOfProj = 1;

    //*****************************

    //**********% VALUES***********
    private float incFireDmg = 0;
    private float incFireAoE = 0;
    private float incFireDur = 0;
    private float incFireProjSpeed = 0;

    private float incLightDmg = 0;
    private float incLightAoE = 0;
    private float incLightDur = 0;
    private float incLightProjSpeed = 0;

    private float incWaterDmg = 0;
    private float incWaterAoE = 0;
    private float incWaterDur = 0;
    private float incWaterProjSpeed = 0;

    private float incGravityDmg = 0;
    private float incGravityAoE = 0;
    private float incGravityDur = 0;
    private float incGravityProjSpeed = 0;

    private float chancetoFreeze = 0;
    private float knockbackRes = 0;
    private float cooldownRed = 0;
    private float incMoveSpeed = 0;
    private float damageRed = 0;
    //******************************

    public float this[string i]
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
                    maxLife = (int) minimumValue(value, 100);
                    break;
                case "curLife":
                    curLife = (int) minimumValue(value, 0);
                    break;
                case "numberOfProj":
                    numberOfProj = (int)minimumValue(value, 1); ;
                    break;
                case "incFireDmg":
                    incFireDmg = minimumValue(value, -1);;
                    break;
                case "incFireAoE":
                    incFireAoE = minimumValue(value, -1);;
                    break;
                case "incFireDur":
                    incFireDur = minimumValue(value, -1);;
                    break;
                case "incFireProjSpeed":
                    incFireProjSpeed = minimumValue(value, -1);;
                    break;
                case "incLightDmg":
                    incLightDmg = minimumValue(value, -1);;
                    break;
                case "incLightAoE":
                    incLightAoE = minimumValue(value, -1);;
                    break;
                case "incLightDur":
                    incLightDur = minimumValue(value, -1);;
                    break;
                case "incLightProjSpeed":
                    incLightProjSpeed = minimumValue(value, -1);;
                    break;
                case "incWaterDmg":
                    incWaterDmg = minimumValue(value, -1);;
                    break;
                case "incWaterAoE":
                    incWaterAoE = minimumValue(value, -1);;
                    break;
                case "incWaterDur":
                    incWaterDur = minimumValue(value, -1);;
                    break;
                case "incWaterProjSpeed":
                    incWaterProjSpeed = minimumValue(value, -1);;
                    break;
                case "incGravityDmg":
                    incGravityDmg = minimumValue(value, -1);;
                    break;
                case "incGravityAoE":
                    incGravityAoE = minimumValue(value, -1);;
                    break;
                case "incGravityDur":
                    incGravityDur = minimumValue(value, -1);;
                    break;
                case "incGravityProjSpeed":
                    incGravityProjSpeed = minimumValue(value, -1);;
                    break;
                case "chanceToFreeze":
                    chancetoFreeze = minimumValue(value, -1);;
                    break;
                case "knockbackRes":
                    knockbackRes = minimumValue(value, -1);;
                    break;
                case "cooldownRed":
                    cooldownRed = minimumValue(value, -1);;
                    break;
                case "incMoveSpeed":
                    incMoveSpeed = minimumValue(value, -1);
                    break;
                default:
                    //not a valid attribute
                    break;
            }
        }
    }

    float minimumValue(float value, float min) {
        return value >= min ? value : min;
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
