using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableParticles : MonoBehaviour
{

    [SerializeField] private GameObject particles;
    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == true)
        {
           if (!isPlaying)
           {
             Instantiate(particles, this.gameObject.transform);
             isPlaying = true;
           }
        }
    }
}
