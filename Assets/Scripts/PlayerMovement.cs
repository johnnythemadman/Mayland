using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D body;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePosition;

    public GameObject firePoint;
    
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        CalcMovement();
        CalcMousePosition();
    }

    void FixedUpdate()
    {
        UpdatePosition();
        LookAt(mousePosition);
    }

    private void CalcMovement()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
    }

    private void CalcMousePosition()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UpdatePosition()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void LookAt(Vector2 target)
    {
        var direction = target - new Vector2(firePoint.transform.position.x, firePoint.transform.position.y);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        body.rotation = angle;
    }
}
