using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float AIInputTimeDelay = 1f;
    public List<int> usedInput = new List<int>();
    public UserInput RandomAIInput()
    {
        int randomInput = Random.Range(2, 6);
        int maxIter = 0;
        while (usedInput.Contains(randomInput) && maxIter <= 10)
        {
            randomInput = Random.Range(2, 6);
            maxIter++;
        }
        if(!usedInput.Contains(randomInput))
            usedInput.Add(randomInput);
        return (UserInput)randomInput;
    }
}
