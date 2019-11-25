using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private SlingShotLine slingShotLine;
    [SerializeField] private bool isPressed;

    private float releaseDelay;
    private float maxDragDistance = 2f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpringJoint2D sj;
    [SerializeField] private Rigidbody2D slingRb;

    [SerializeField] private GameObject bird1;
    [SerializeField] private GameObject bird2;
    [SerializeField] private GameManager gameManager;

    private void Awake() //Defines all the variables that need Finding in the scene
    {
        gameManager = GameObject.Find(Constants.gameManager).GetComponent<GameManager>();
        slingShotLine = GameObject.Find(Constants.slingShotBack).GetComponent<SlingShotLine>();
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        sj.connectedBody = GameObject.Find(Constants.centrePoint).GetComponent<Rigidbody2D>();
        slingRb = sj.connectedBody;
    }

    private void Start() //calculates the delay of the slingshot and freezes the bird in place as to not make it look like a yo-yo
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        releaseDelay = 1 / (sj.frequency * 4);

        isPressed = false;
    }

    void Update()
    {
        if(isPressed)
        {
            DragBall();
        }
    }

    private void DragBall() //Puts the bird on the position of the mouse and keeps it from going beyond the limited range within the game
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingRb.position);

        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }
    }

    private void OnMouseDown() //Checks if the player is draggin the bird
    {
        rb.constraints = RigidbodyConstraints2D.None;
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() //Checks if the player releases the bird
    {
        isPressed = false;
        StartCoroutine(Release());
        rb.isKinematic = false;
    }

    private IEnumerator Release() //Disables the line renderer and prepares the game manager for another bird to spawn + disables the Spring joint
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        gameManager.setBool(true);
        slingShotLine.setLineRendererActive(false);
    }
}
