using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeableDoor : DoorBase, IBreakeable
{
    public void Break()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator AIInputSelection(AIController AIInput)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayerInputSelection()
    {
        throw new System.NotImplementedException();
    }
}
