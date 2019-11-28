using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    [SerializeField] private float radius = 5.0F; 
    [SerializeField] private float power = 10.0F; 
    [SerializeField] private LayerMask obstacleLayer; 
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private AudioSource explosionAudio; 
    [SerializeField] private AudioClip explosion; 
    [SerializeField] private AudioClip explosionTimer; 
    [SerializeField] private bool canExplode = true;
    [SerializeField] private bool playTimer = true;
    [SerializeField] private bool startTimer = true; 
    [SerializeField] private ParticleSystem boomParticles;
    Collider2D[] colliders;
    Vector2 explosionPos = new Vector2(0,0);
    Rigidbody2D rb;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private GameObject other;

    private void Start()
    {
        playerRb.AddForce(new Vector2(300*playerRb.mass,45*playerRb.mass));
    }

    void Update() 
    {
        
        Vector3 explosionPos = transform.position;
        colliders = Physics2D.OverlapCircleAll(explosionPos, radius, obstacleLayer);
        
        
            if (Input.GetKeyDown("space")&&canExplode == true)
            {
            playTimer = false;
            StartCoroutine(ExplosionTimer());
            }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.layer == 8 && startTimer == true || collision.gameObject.layer == 9 && startTimer == true)
        {

            StartCoroutine(ExplosionTimer());
            //collision.gameObject.GetComponent<Collider2D>().enabled = false;

        }
    }



   /* 
    void OnTriggerStay2D(BoxCollider2D col)
    {
        if (col.gameObject.tag == "Destroyable")
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    */

    private IEnumerator ExplosionTimer()
    {

        if (playTimer == true) 
        {
            startTimer = false;
            explosionAudio.clip = explosionTimer;
            explosionAudio.Play();
            yield return new WaitForSeconds(explosionAudio.clip.length);
            playTimer = false;
            

        }
        else
        {
            yield return new WaitForSeconds(2);
            Destroy(this.gameObject);
        }
        


        foreach (Collider2D hit in colliders) 
        {
            rb = hit.GetComponent<Rigidbody2D>();
            AddExplosionForce(rb, power, transform.position, radius);
        }
        canExplode = false;
        boomParticles.Play();
    }

    void AddExplosionForce(Rigidbody2D rb,float explosionForce, Vector2 explodingPosition, float radius, float upwardsModifier = 0.0f, ForceMode2D mode = ForceMode2D.Impulse)
    {

        if (canExplode == true)
        {
            explosionAudio.clip = explosion;
            Vector2 explodingDirection = rb.position - explodingPosition;
            float explodingDistance = explodingDirection.magnitude;
            explosionAudio.Play();
            if (upwardsModifier == 0)
            {
                explodingDirection /= explodingDistance;

            }
            else
            {
                explodingDirection.Normalize();
            }
            rb.AddForce(Mathf.Lerp(0, explosionForce, (radius / explodingDistance)) * explodingDirection, mode);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
