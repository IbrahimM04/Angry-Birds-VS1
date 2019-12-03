using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour
{
    [SerializeField]private Color color;
    [SerializeField]private int currentHealth;

    void Start()
    {
        currentHealth = 4;
    }

    public void setHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth == 4)
        {
            //block state full hp
            this.color = Color.green;
        }

        if (currentHealth == 3)
        {
            //block state 3/4 hp
            this.color = Color.blue;
        }

        if (currentHealth == 2)
        {
            //block state 1/2 hp
            this.color = Color.yellow;
        }

        if (currentHealth == 1)
        {
            //block state 1/4 hp
            this.color = Color.red;
        }

        if (currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            print(currentHealth);
            currentHealth --;
        }
    }
}
