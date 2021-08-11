using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyInSec : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy = 0.1f;
    void Start()
    {
        Destroy (gameObject, secondsToDestroy);
    }

   
}
