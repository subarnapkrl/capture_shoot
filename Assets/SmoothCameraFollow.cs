using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    
    public Vector3 offset=new Vector3(5f,5f,-10f);
    private float smoothTime=0.25f;
    private Vector3 velocity=Vector3.zero;

    [SerializeField] Transform target;

    private void FixedUpdate() {
        if(target!=null)
        {
            Vector3 targetPosition=target.position+offset;
        transform.position=Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothTime);
        }
        
    }
}
