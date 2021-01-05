using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float AIInputTimeDelay = 1f;
    public List<int> usedInput;
    public UserInput RandomAIInput()
    {
        int randomInput = Random.Range(2, 5);
        while (usedInput.Contains(randomInput))
            randomInput = Random.Range(2, 5);
        usedInput.Add(randomInput);
        return (UserInput)randomInput;
    }
}
