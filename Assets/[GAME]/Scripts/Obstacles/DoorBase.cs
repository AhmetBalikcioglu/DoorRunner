using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorBase : MonoBehaviour
{
    public abstract void InputSelection();
    protected abstract void Animation();
}
