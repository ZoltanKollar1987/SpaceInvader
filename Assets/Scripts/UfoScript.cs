using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour
{
    [SerializeField] float ufoSpeed;
    [SerializeField] GameMaster gameMasterScript;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
  
    void Update()
    {
        UfoMovement();       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.ufoDestroy);
            gameMasterScript.score += 10;
        }
    }

    void UfoMovement()
    {
        transform.Translate(Vector2.left * ufoSpeed * Time.deltaTime);
        audioManager.PlaySFX(audioManager.ufoMove);


        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
