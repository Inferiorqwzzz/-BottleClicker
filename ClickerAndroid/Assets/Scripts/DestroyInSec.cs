using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyInSec : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy = 10f;
    void Start()
    {
        Destroy (gameObject, secondsToDestroy);
    }

   
}
