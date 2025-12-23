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
        startPosition = transform.localPosition;
        PickNewDestination();
    }

    private void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, currentDestination, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.localPosition, currentDestination) < 0.1f)
        {
            PickNewDestination();
        }
    }

    private void PickNewDestination()
    {
        Vector2 randomPoint = Random.insideUnitCircle * wanderRadius;
        currentDestination = startPosition + randomPoint;
    }
}
