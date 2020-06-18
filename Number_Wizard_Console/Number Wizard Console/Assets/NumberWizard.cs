using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max;
    int min;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;

        Debug.Log("========================");
        Debug.Log("Welcome to Number Wizard");
        Debug.Log("Pick a random number, don't tell me what it is... ");
        Debug.Log("The highest number you can pick is: " + max);
        Debug.Log("The lowest number you can pick is: " + min);
        Debug.Log("Tell me if your number is higher or lower than " + guess + "...");
        Debug.Log("Push Up = higher, Push Down = lower, Enter = Correct!");
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Detect when the up arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow key was pressed!");
            min = guess;
            NextGuess();
        }

        //Detect when the down arrow key is pressed down
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was pressed.");
            max = guess;
            NextGuess();
        }

        //Detect when the enter key is pressed down
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I predicted correctly!");
            StartGame();
        }

    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log("It is higher or lower than " + guess + "?");
    }
}
