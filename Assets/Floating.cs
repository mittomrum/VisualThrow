using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

    public float timePeriod = 2f;
    public float height = 1f;
    public float maxRandomOffset = 0.2f;
    private float timeSinceStart;
    private Vector3 pivot;
    private float randomOffset;

    private void Start()
    {
        pivot = transform.position;
        timeSinceStart = Random.Range(0f, timePeriod);
        randomOffset = Random.Range(-maxRandomOffset, maxRandomOffset);
    }

    private void FixedUpdate()
    {
        float cycleTime = (timeSinceStart + randomOffset) % timePeriod;
        float cycleProgress = cycleTime / timePeriod;

        float targetHeight = Mathf.Sin(cycleProgress * Mathf.PI) * height;
        Vector3 nextPos = transform.position;
        nextPos.y = pivot.y + targetHeight;
        transform.position = nextPos;

        timeSinceStart += Time.fixedDeltaTime;
    }
}
