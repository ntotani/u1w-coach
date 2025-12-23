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
        pointsInTime.Enqueue(new PointInTime(target.position, Time.time));
        while (pointsInTime.Count > 0 && Time.time - pointsInTime.Peek().time >= delaySeconds)
        {
            PointInTime point = pointsInTime.Dequeue();
            transform.position = point.position + offset;
        }
    }
}
