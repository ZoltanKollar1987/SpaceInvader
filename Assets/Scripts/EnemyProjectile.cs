using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(-Vector2.up * speed * Time.deltaTime);
        DestroyEnemyProjectile();
    }
    void DestroyEnemyProjectile()
    {
        if (gameObject.transform.position.y <= -6f)
        {
            Destroy(this.gameObject);
        }
    }

    
}
