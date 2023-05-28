using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    public float speed = 5f;
    public float movementThreshold = 1f;
    public float mouseDistanceThreshold = 0.5f;
    public Animator animator;

    private Vector3 target;
    private bool isMoving;
    private Collider2D playerCollider;

    private void Start()
    {
        target = transform.position;
        isMoving = false;
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distanceToMouse = Vector3.Distance(transform.position, mousePosition);

        if (distanceToMouse > mouseDistanceThreshold && !IsMouseOverPlayer(mousePosition))
        {
            target = GetRandomVectorOppositeToMouse(mousePosition);
            isMoving = true;
        }

        if (isMoving)
        {
            Move();

            if (!IsMoving())
                animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private bool IsMoving()
    {
        float distance = Vector2.Distance(transform.position, target);
        return distance >= movementThreshold;
    }

    private bool IsMouseOverPlayer(Vector3 mousePosition)
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseScreenPosition = new Vector3(mousePosition.x, mousePosition.y, playerScreenPosition.z);
        return playerCollider.OverlapPoint(mouseScreenPosition);
    }

    private Vector3 GetRandomVectorOppositeToMouse(Vector3 mousePosition)
    {
        Vector3 oppositeDirection = -(mousePosition - transform.position).normalized;
        float randomDistance = Random.Range(1f, 5f);
        Vector3 randomTarget = transform.position + oppositeDirection * randomDistance;
        return randomTarget;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            isMoving = false;
        }
    }
}
