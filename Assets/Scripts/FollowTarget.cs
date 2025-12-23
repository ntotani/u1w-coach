using UnityEngine;
using System.Collections.Generic;

public class FollowTarget : MonoBehaviour
{
    [Header("Follow Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private float delaySeconds = 1f;
    [SerializeField] private Vector3 offset;

    private struct PointInTime
    {
        public Vector3 position;
        public float time;

        public PointInTime(Vector3 pos, float t)
        {
            position = pos;
            time = t;
        }
    }

    private Queue<PointInTime> pointsInTime;

    private void Start()
    {
        pointsInTime = new Queue<PointInTime>();
    }

    private void Update()
    {
        if (target == null) return;

        // Record target's current position and time
        pointsInTime.Enqueue(new PointInTime(target.position, Time.time));

        // Check if the oldest record is older than the delay time
        // We loop to catch up if multiple frames' worth of time has passed
        while (pointsInTime.Count > 0 && Time.time - pointsInTime.Peek().time >= delaySeconds)
        {
            // Move to the position recorded 'delaySeconds' ago
            PointInTime point = pointsInTime.Dequeue();
            transform.position = point.position + offset;
        }
    }
}
