using System.Collections;
using UnityEngine;

//For things that need to move via force
public interface IMovable
{
    void Push(Vector3 force);
    void Teleport(Vector3 position);
}
