using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip[] breakSound;
    [SerializeField] AudioClip metalSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference (with FindObjectOfType): Reference to other objects in the game
    Level level;
    GameSession gameStatus;

    // State variables: To keep track state of something (e.g. number of hits...)
    [SerializeField] int timesHit; // TODO: Serialized only for debugging
    [SerializeField] int scoreMultiplier;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
        else if (tag == "Unbreakable")
        {
            playMetalSFX();
        }
    }

    private void playMetalSFX()
    {
        AudioSource.PlayClipAtPoint(metalSound, Camera.main.transform.position);
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
            PlayNextBreakSFX();
        }
    }


    private void PlayNextBreakSFX()
    {
        int SFXIndex = timesHit - 1;
        if(breakSound[SFXIndex] != null)
        {
            AudioSource.PlayClipAtPoint(breakSound[SFXIndex], Camera.main.transform.position);
        }
        else
        {
            Debug.LogError("SFX is missing from array" + gameObject.name);
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
        ScoreBlockDestroyed();
    }

    private void ScoreBlockDestroyed()
    {
        //scoreMultiplier = hitSprites.Length + 1;
        gameStatus = FindObjectOfType<GameSession>();
        gameStatus.AddToScore();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound[breakSound.Length - 1], Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
