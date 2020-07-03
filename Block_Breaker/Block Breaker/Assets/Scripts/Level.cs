using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    // Parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging, not to change it in Unity
    //[SerializeField] TextMeshProUGUI levelText;
    //[SerializeField] int level = 0;
    [SerializeField] AudioClip audioSuccess;

    // Cached reference
    SceneLoader sceneLoader;
    Ball myBall;
    Rigidbody2D myBallRigidBody2D;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        myBall = FindObjectOfType<Ball>();
        myBallRigidBody2D = myBall.GetComponent<Rigidbody2D>();
        //levelText.SetText("Level {0}", sceneLoader.GetIndexLevel());
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            StopBall();
            AudioSource.PlayClipAtPoint(audioSuccess, Camera.main.transform.position);
            Invoke("loadNext", 2f);
        }
    }

    private void StopBall()
    {
        Vector2 velStop = new Vector2(0, 0);
        myBallRigidBody2D.velocity = velStop;
    }

    public void loadNext()
    {
        sceneLoader.LoadNextScene();
    }
}
