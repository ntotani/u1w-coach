using UnityEngine;

public class FloatingWobble : MonoBehaviour
{
    [Header("Wobble Settings")]
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        // Calculate vertical offset using Sin wave
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        
        // Apply offset to the start position
        transform.localPosition = startPos + Vector3.up * yOffset;
    }
}
