using System.Collections;
using UnityEngine;

//For things that need to generate a random number
public interface IGenerator
{
    int Generate(int min, int max);
}

