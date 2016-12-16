using System.Collections;
using UnityEngine;

//For things that need to move via force
public interface Moveable
{
    void Move(float value, Vector3 direction);
}
