using System.Collections;
using UnityEngine;

//For things that need to be able to be pushed or pulled in some way
public interface IForceable
{
    void Push(float magnitude, Transform away);

    void Pull(float magnitude, Transform toward);

    void Force(Vector3 force);
}
