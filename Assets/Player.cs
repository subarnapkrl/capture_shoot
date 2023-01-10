using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    Rigidbody2D rb;
    Camera mainCamera;

     float moveSpeed=8f;
    float moveHorizontal;
    float moveVertical;
    float speedLimiter=0.7f;
    Vector2 moveVelocity;

    Vector2 mousePos;
    Vector2 offset;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    public GameObject player;
    

    bool isShooting=false;
    float bulletSpeed=15f;

    [SerializeField] float increase;

    [SerializeField] GameObject playerParticleSystem;
    

   

    // Start is called before the first frame update
    void Start()
    {
       rb=gameObject.GetComponent<Rigidbody2D>(); 
       mainCamera=Camera.main;
        
      
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal=Input.GetAxis("Horizontal");
        moveVertical=Input.GetAxis("Vertical");

        moveVelocity=new Vector2(moveHorizontal,moveVertical)*moveSpeed;

        if(transform.position.y>30f)
        {
            transform.position=new Vector3(transform.position.x,30f,0f);
        }
        if(transform.position.y<-30f)
        {
            transform.position=new Vector3(transform.position.x,-30f,0f);
        }
        if(transform.position.x>35f)
        {
            transform.position=new Vector3(35f,transform.position.y,0f);
        }

        if(transform.position.x<-35f)
        {
            transform.position=new Vector3(-35f,transform.position.y,0f);
        }
        

        if(Input.GetMouseButtonDown(0))
        {
            isShooting=true;
            
        }
        if(transform.localScale.x>2.8f && transform.localScale.y>2.8f){
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        MovePlayer();
        RotatePlayer();

        if(isShooting)
        {
            StartCoroutine(StartFire());
            
            
            
            
           
        }
    }

    void MovePlayer()
    {
        if(moveHorizontal!=0 || moveVertical!=0)
        {
            if(moveHorizontal!=0 && moveVertical!=0)
            {
                moveVelocity=moveVelocity*speedLimiter;
            }
            rb.velocity=moveVelocity;
        }else{
            moveVelocity=new Vector2(0f,0f);
            rb.velocity=moveVelocity;
        }
    }

    void RotatePlayer()
    {
        mousePos=Input.mousePosition;

        Vector3 screenPoint=mainCamera.WorldToScreenPoint(transform.localPosition);

        offset=new Vector2(mousePos.x-screenPoint.x,mousePos.y-screenPoint.y).normalized;

        float angle=Mathf.Atan2(offset.y,offset.x)*Mathf.Rad2Deg;

        transform.rotation=Quaternion.Euler(0f,0f,angle-90);
    }

    IEnumerator StartFire()
    {
        isShooting=false;

        GameObject bullets=Instantiate(bullet,bulletSpawn.transform.position,Quaternion.identity);
        bullets.GetComponent<Rigidbody2D>().velocity=offset*bulletSpeed;
        
        transform.localScale=transform.localScale-new Vector3(increase,increase,increase);
        if(transform.localScale.x<0.6f && transform.localScale.y<0.6f  )
        {   
            Destroy(gameObject);
            Instantiate(playerParticleSystem,transform.position,Quaternion.identity);

        }

         
        yield return new WaitForSeconds(2f);
        Destroy(bullets,1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Coins")
        {
            Destroy(other.gameObject);
            transform.localScale=transform.localScale+new Vector3(increase,increase,increase);

        }
        else if(other.gameObject.tag=="Coins 2")
        {
            Destroy(other.gameObject);
            transform.localScale=transform.localScale+new Vector3(0.2f,0.2f,0f);

        }
        if(other.gameObject.tag=="Coins 3")
        {
            Destroy(other.gameObject);
            transform.localScale=transform.localScale+new Vector3(0.3f,0.3f,0f);

        }
    }
}
