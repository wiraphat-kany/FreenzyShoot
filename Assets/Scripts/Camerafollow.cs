using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
   [SerializeField] private Transform _traget;
   [SerializeField] private Vector3 offset;
    [Range(1, 10)] 
    [SerializeField]  private float smootFactor;
    
    void FixedUpdate()
    {
       Follow();
    }

    void Follow()
    {
        Vector3 tragetPosition = _traget.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, tragetPosition, smootFactor * Time.fixedDeltaTime);
        transform.position = tragetPosition;
    }
}
