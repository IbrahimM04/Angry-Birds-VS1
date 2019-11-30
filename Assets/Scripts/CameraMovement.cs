﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(moveCameraBack());    
    }

    public IEnumerator moveCamera()
    {
        while (transform.position.x < 10)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position += new Vector3(0.1f, 0);
        }
    }

    public IEnumerator moveCameraBack()
    {
        yield return new WaitForSeconds(1); 
        while (transform.position.x > 0)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position -= new Vector3(0.1f, 0);
        }
    }
}
