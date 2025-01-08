using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] bool directionChange;
    [SerializeField] public GameObject[] enemies;
    float playMusicCountdown;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = 0.2f;
        directionChange = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
       
        Movement();
       
        
    }

    void Movement()
    {

        MovementMusic();
        if( enemies.Length <= 34)
        {
            enemySpeed = 0.8f;
            
        }
        if (enemies.Length <= 24)
        {
            enemySpeed = 1f;
            
        }
        if (enemies.Length <= 14)
        {
            enemySpeed = 1.2f;
            
        }
        if (enemies.Length <= 4)
        {
            enemySpeed = 2f;
            
        }

        if (directionChange == false)
        {
            
            transform.Translate(-Vector3.left * enemySpeed * Time.deltaTime);
            if (transform.position.x >= 3)
            {
                directionChange = true;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }
        
        if (directionChange == true)
        {
            
            transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
           if(transform.position.x <= -3)
            {
                directionChange = false;
                transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
            }
        }

                     
    }  

    void MovementMusic()
    {
        //float playMusicTimer = 0.5f;
        

        playMusicCountdown -= Time.deltaTime;
        Debug.Log(playMusicCountdown);
        if (playMusicCountdown <= 0)
        {
            audioManager.PlaySFX(audioManager.enemyMove);
            playMusicCountdown = 1.5f;
        }
    }

    
    
}
