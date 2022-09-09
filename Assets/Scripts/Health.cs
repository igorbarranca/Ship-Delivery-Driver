using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Sprite deadSprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] GameManager gameManager;

    public bool IsAlive = true;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("GAME OVER");
        AudioPlayer.instance.PlayCrashClip();
        IsAlive = false;
        spriteRenderer.sprite = deadSprite;
        
        gameManager.GameOver();
    }
}
