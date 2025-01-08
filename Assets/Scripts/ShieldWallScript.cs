using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldWallScript : MonoBehaviour
{
    [SerializeField] int shieldWallLife;

    // Start is called before the first frame update
    void Start()
    {
        shieldWallLife = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            shieldWallLife--;
            
            if (shieldWallLife <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        

        if (collision.collider.CompareTag("Projectile"))   
        {
            Destroy(collision.gameObject);
        }

       
    }
    
    

}
