using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.getStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState2();
 
    }

    private void ManageState2()
    {
        var nextStates = state.getNextStates();
        for(int idx = 0; idx < nextStates.Length; idx++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + idx))
            {
                state = nextStates[idx];
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        textComponent.text = state.getStateStory();
    }
     
    private void ManageState()
    {
        var nextStates = state.getNextStates(); // var is equal to State[]
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextStates[2];
        }

        textComponent.text = state.getStateStory();
    }
}
