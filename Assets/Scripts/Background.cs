using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    private float tileSize;
    public bool isScrolling = true;
    private void Start()
    {
        // Assuming your background sprite is horizontally tiled, get its size
        tileSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        if (isScrolling)
        {
            // Move the background horizontally
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // Check if the background needs to loop
            if (transform.position.x < -tileSize)
            {
                RepositionBackground();
            }
        }
    }

    private void RepositionBackground()
    {
        // Calculate the new position for the background to create a looping effect
        Vector3 newPos = new Vector3(tileSize * 1.99f, 0, 0);
        transform.position = transform.position + newPos;

        
    }
    public void StopScrolling()
    {
        isScrolling = false;
    }

}