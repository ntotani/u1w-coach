using UnityEngine;

public class WanderingMovement : MonoBehaviour
{
    [Header("Wandering Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float wanderRadius = 3f;

    private Vector2 startPosition;
    private Vector2 currentDestination;

    private void Start()
    {
        // Remember the starting position as the center of the wandering area
        startPosition = transform.position;
        PickNewDestination();
    }

    private void Update()
    {
        // Move towards the current destination
        transform.position = Vector2.MoveTowards(transform.position, currentDestination, moveSpeed * Time.deltaTime);

        // Check if we have reached the destination
        if (Vector2.Distance(transform.position, currentDestination) < 0.1f)
        {
            PickNewDestination();
        }
    }

    private void PickNewDestination()
    {
        // Pick a random point within the radius around the start position
        Vector2 randomPoint = Random.insideUnitCircle * wanderRadius;
        currentDestination = startPosition + randomPoint;
    }
}
