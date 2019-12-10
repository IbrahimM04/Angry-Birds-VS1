using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{

    private float time;

    void awake()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {


            if (time <= 3)
            {
                print(time);

            }

            if (time > 3)
            {

                Destroy(this.gameObject);
            }
            time += 0.01f;
        }
    }
}
