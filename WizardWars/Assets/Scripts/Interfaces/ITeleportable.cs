using System.Collections;
using UnityEngine;

//For things that need to instantaneously change positions
public interface ITeleportable
{
    void Teleport(Vector3 position);
}