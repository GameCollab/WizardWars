using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : Effect {
    public Enums.Cards.Interrupt _interrupt;
    public float _duration;
    [HideInInspector]
    public bool _isInterruptedFlag;
    [HideInInspector]
    public float _timer;
    // Use this for initialization
    void Start() {

    }

    void OnEnable()
    {
        _isTargeted = true;
        _timer = 0f;
    }

    void Update() {
        if (!Done())
        {
            DoDiscrete();
            _timer += Time.deltaTime;
            if(_timer > _duration)
            {
                _doneWithDiscrete = true;
            }
        }
    }

    private bool CheckForInterrupts()
    {
        switch (_interrupt)
        {
            case Enums.Cards.Interrupt.ANY:
                //Call Player.IsInterrupted
                return true;
            case Enums.Cards.Interrupt.SELF:
                //Call Player.IsTakingAction
                return true;
            default:
                return false;
        }
    }

    public override void DoDiscrete()
    {
        if (CheckForInterrupts())
        {
            _isInterruptedFlag = true;
        }
    }

    public override bool Done()
    {
        return _doneWithDiscrete;
    }
}
