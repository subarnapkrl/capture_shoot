using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    private Transform target;
    Transform enemyPos;
   
   public GameObject player;

   public GameObject explosionEnemyEffect;
   public GameObject playerExplode;

   GameManager gm;
    

    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    enemyPos=GetComponent<Transform>();
    gm=GetComponent<GameManager>();
    

    
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        {
            transform.position=Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player")
        {
            if(transform.localScale.sqrMagnitude<other.transform.localScale.sqrMagnitude)
            {
                other.transform.localScale+=gameObject.transform.localScale;
                Destroy(gameObject);
                Instantiate(explosionEnemyEffect,transform.position,Quaternion.identity);

            }else{
                Destroy(other.gameObject);
                Instantiate(playerExplode,transform.position,Quaternion.identity);
            }
            
            
        }
    }
}
