using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingController2D : CharacterController2D
{
    void Update()
    {
        UpdateGrounding();
    }
}
