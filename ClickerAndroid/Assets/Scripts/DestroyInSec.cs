using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyInSec : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy = 10f;
    public Rigidbody2D rb;

    public Vector2 movement; 

    public float speed = 1f; 
    void Start()
    {
        movement = new Vector2 (UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(movement * speed);
        Destroy (gameObject, secondsToDestroy);
    }

   
}
