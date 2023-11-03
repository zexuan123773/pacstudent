using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    // Pacman's speed
    public float speed = 0.35f;
    // Pacman's next position
    private Vector2 dest = Vector2.zero;

    private void Start()
    {
        // Make sure Pacman won't move when the game starts
        dest = transform.position;
    }

    private void FixedUpdate()
    {
        // Interpolate to get the coordinates of the next move towards the dest position
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);
        // Set the position of the object with a rigid body
        GetComponent<Rigidbody2D>().MovePosition(temp);
        // The previous dest position must be reached before a new position detection command can be issued
        if ((Vector2)transform.position == dest)
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            // Get moving direction
            Vector2 dir = dest - (Vector2)transform.position;
            // Set the obtained movement direction to the animation state machine
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }

    // Check whether the location you are going to is reachable
    private bool Valid(Vector2 dir)
    {
        // Record your current location
        Vector2 pos = transform.position;
        // A ray is emitted from the position to be reached towards the current position
        // And store the ray's information
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        // Returns whether this ray reached the collider on Pac-Man
        return (hit.collider == GetComponent<Collider2D>());
    }
}
