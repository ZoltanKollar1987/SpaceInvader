using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    

    // Update is called once per frame
    void Update()
    {
        ProjectileMovement();
        DestroyProjectile();
    }

    void ProjectileMovement()
    {
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        if(gameObject.transform.position.y >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }

}
