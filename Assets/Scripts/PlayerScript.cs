using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject canon;
    [SerializeField] float canonReload;
    [SerializeField] public int playerLife;
    [SerializeField] Image[] playerLifeConter;
    public Vector2 actualPos;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        playerLife = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        
       PlayerMovement();
       Boundaries();
       Shoot();
        
    }

    void PlayerMovement()
    {    
        
            if (Input.GetKey(KeyCode.A))
            {
               transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
            }
            

            if (Input.GetKey(KeyCode.D))
            {   
               transform.Translate(-Vector2.left * playerSpeed * Time.deltaTime);
            }

    }

    
    void Shoot()
    {
        canonReload -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)&& canonReload <=0)
        {
            audioManager.PlaySFX(audioManager.playerShoot);
            Instantiate(projectile, canon.transform.position, Quaternion.identity);
            canonReload = 1f;
        }
    }

    public void PlayerLifeLoss(int playerLife)
    {
        
        if (playerLife == 3)
        {
            playerLifeConter[0].gameObject.SetActive(false);
        }
        if(playerLife == 2)
        {
            playerLifeConter[1].gameObject.SetActive(false);
        }
        if (playerLife == 1)
        {
            playerLifeConter[2].gameObject.SetActive(false);
        }
        if (playerLife == 0)
        {
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.playerDestroy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyProjectile"))
        {
            
            Destroy(collision.collider.gameObject);
            playerLife -= 1;
            PlayerLifeLoss(playerLife);
            
        }
    }

    void Boundaries()
    {
        actualPos = transform.position;

        if (transform.position.x <= -8)
        {
            transform.position = new Vector3(-8,transform.position.y,transform.position.z);
        }
        if(transform.position.x >= 8)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }
    }

    
}
