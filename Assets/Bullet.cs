using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
//  Transform enemy;
//  Transform enemy2;
GameObject enemy,enemy2,enemy3,enemy4;
   public GameObject explosionEnemyEffect;
    // Start is called before the first frame update
    void Start()
    {
        enemy=GameObject.FindGameObjectWithTag("Enemy");
        enemy2=GameObject.FindGameObjectWithTag("Enemy2");
        enemy3=GameObject.FindGameObjectWithTag("Enemy3");
        enemy4=GameObject.FindGameObjectWithTag("Enemy4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Enemy")
        {
            enemy.transform.localScale=enemy.transform.localScale-new Vector3(0.2f,0.2f,0.2f);
            if(enemy.transform.localScale.x<0.5f && enemy.transform.localScale.y<0.5f)
            {
                Destroy(other.gameObject);
                  Instantiate(explosionEnemyEffect,transform.position,Quaternion.identity);
            }

            Destroy(gameObject);
            
        }
        if(other.gameObject.tag=="Enemy2")
        {
            enemy2.transform.localScale=enemy2.transform.localScale-new Vector3(0.3f,0.3f,0.3f);
            if(enemy2.transform.localScale.x<0.7f && enemy2.transform.localScale.y<0.7f)
            {
                Destroy(other.gameObject);
                  Instantiate(explosionEnemyEffect,transform.position,Quaternion.identity);
            }
            
            Destroy(gameObject);
            
        }

        if(other.gameObject.tag=="Enemy3")
        {
            enemy3.transform.localScale=enemy3.transform.localScale-new Vector3(0.3f,0.3f,0.3f);
            if(enemy3.transform.localScale.x<0.8f && enemy3.transform.localScale.y<0.8f)
            {
                Destroy(other.gameObject);
                  Instantiate(explosionEnemyEffect,transform.position,Quaternion.identity);
            }
            
            Destroy(gameObject);
            
        }
        if(other.gameObject.tag=="Enemy4")
        {
            enemy4.transform.localScale=enemy4.transform.localScale-new Vector3(0.3f,0.3f,0.3f);
            if(enemy4.transform.localScale.x<1.1f && enemy4.transform.localScale.y<1.1f)
            {
                Destroy(other.gameObject);
                  Instantiate(explosionEnemyEffect,transform.position,Quaternion.identity);
            }
            
            Destroy(gameObject);
            
        }
        
    }
}
