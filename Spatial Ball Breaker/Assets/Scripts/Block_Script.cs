using System;
using UnityEngine;

public class Block_Script : MonoBehaviour
{
    public int ScoreAward;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;
    Level level;
    [SerializeField] int timesHit;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
            level.CountBreakeableBlocks();
        }

    }
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        try
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        catch (IndexOutOfRangeException)
        {
            Debug.LogWarning($"Index {spriteIndex} of {gameObject.name} is out of range");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player" && tag == "Breakable")
        {
            GameStatus status = FindObjectOfType<GameStatus>();
            timesHit++;
            TriggerSparkleVFX();
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            if (timesHit >= maxHits)
            {
                status.scoreObtained += ScoreAward;
                status.scoreText.text = status.scoreObtained.ToString();
                level.BlockDestroyed();
                Destroy(gameObject);
                return;
            }
            ShowNextHitSprite();
        }
    }
    public void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
    }
}