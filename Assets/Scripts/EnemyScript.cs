using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameMaster GameMasterScore;
    [SerializeField] GameObject EnemyProjectile;
    [SerializeField] GameObject EnemyProjectilePos;
    [SerializeField] bool allowedToShoot;
    [SerializeField] PlayerScript playerScript;

    [SerializeField] bool active;

    [SerializeField] float cooldown;
    [SerializeField] float cooldownTimer;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Start()
    {
       allowedToShoot = false;
       cooldownTimer = 0;
       cooldown = Random.Range(10,25);

    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        ShootAllowed();

        if (allowedToShoot && cooldownTimer >= cooldown)
        {
            Shoot();
            cooldownTimer = 0f;
        }
        
    }

    void Shoot()
    {
        audioManager.PlaySFX(audioManager.enemyShoot);
        Instantiate(EnemyProjectile,EnemyProjectilePos.transform.position,Quaternion.identity);
       
    }

    void ShootAllowed()
    {
        RaycastHit2D hit = Physics2D.Raycast(EnemyProjectilePos.transform.position, -Vector2.up,5f);

        if (hit.collider != null)
        {
            
            allowedToShoot = false;       
        }
        else
        {
            
            allowedToShoot = true;   
        }
        
        
        
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            audioManager.PlaySFX(audioManager.enemyDestroy);
            GameMasterScore.score++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.enemyDestroy);
            Destroy(gameObject);
            playerScript.playerLife -= 1;
            playerScript.PlayerLifeLoss(playerScript.playerLife);
            
        }
        if (collision.collider.CompareTag("Wall"))
        {
            audioManager.PlaySFX(audioManager.enemyDestroy);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
