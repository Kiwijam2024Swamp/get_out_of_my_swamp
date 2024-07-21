using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 10f; // Speed of the cloud movement
    public RectTransform startTransform; // Starting position of the cloud (off-screen to the right)
    public RectTransform endTransform; // Ending position of the cloud (off-screen to the left)

    private RectTransform cloudRectTransform;

    void Start()
    {
        cloudRectTransform = GetComponent<RectTransform>();

        // Check if the RectTransform component is attached
        if (cloudRectTransform == null)
        {
            Debug.LogError("RectTransform component is missing from the cloud GameObject.");
            return;
        }

        // Start at the initial position
        cloudRectTransform.position = startTransform.position;
    }

    void Update()
    {
        if (cloudRectTransform == null)
        {
            return;
        }

        // Move the cloud towards the end position
        cloudRectTransform.position = Vector3.MoveTowards(cloudRectTransform.position, endTransform.position, speed * Time.deltaTime);

        // Check if the cloud has reached the end position
        if (cloudRectTransform.position == endTransform.position)
        {
            // Reset to start position
            cloudRectTransform.position = startTransform.position;
        }
    }
}
