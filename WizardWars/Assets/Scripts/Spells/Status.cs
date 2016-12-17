using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : Behavior
{
    float _duration;
    bool _undoable;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public abstract void Undo();
}
