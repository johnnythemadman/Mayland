using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D body;

    private Vector2 movement;
    private Vector2 mousePos;

    public Camera camera;

    // Awake is called when the script instance is being loaded
    // Init all dependencies
    private void Awake()
    {

    }


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
