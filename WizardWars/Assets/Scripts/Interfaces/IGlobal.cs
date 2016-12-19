using System.Collections;
using UnityEngine;

//For things that need to stay alive when scene loading
public interface IGlobal
{
    void SetDontDestroyOnLoad();
}
