using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// For ScriptableObject
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    // SerializeField to make it visible to inspector
    [TextArea(20,24)][SerializeField] string storyText;
    [SerializeField] State[] nextStates;


    public string getStateStory()
    {
        return storyText;
    }

    public State[] getNextStates()
    {
        return nextStates;
    }

}
