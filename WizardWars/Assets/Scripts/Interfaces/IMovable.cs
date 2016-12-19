using System.Collections;
using UnityEngine;

//For things that need to move via force
public interface IMovable
{
    void Move(Vector3 force);
}
