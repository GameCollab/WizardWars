using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable {
    void ApplyStatus(uint status, int from);
}
