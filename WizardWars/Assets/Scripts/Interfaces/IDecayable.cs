using System.Collections;
using UnityEngine;

//For things that decay at some fixed rate
//This may be unecessary, as the same can be done with Damagable
public interface Decayable
{
    void Decay();
}

