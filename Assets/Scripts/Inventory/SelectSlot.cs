using UnityEngine;

public class SelectSlot : MonoBehaviour
{
    private SpriteRenderer[] childSpriteRenderers;
    private Color[] originalColors;

    void Start()
    {
        // Initialize the arrays with the correct size
        childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[childSpriteRenderers.Length];

        // Save the original colors of the child objects' SpriteRenderers
        for (int i = 0; i < childSpriteRenderers.Length; i++)
        {
            originalColors[i] = childSpriteRenderers[i].color;
        }
    }

    void Update()
    {
        // Cast a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        // Check if the ray hits a child object of the "Image" object
        for (int i = 0; i < childSpriteRenderers.Length; i++)
        {
            // Check if the current child object is being hovered over
            if (hit && hit.transform.IsChildOf(transform) && hit.transform == childSpriteRenderers[i].transform)
            {
                // Change the color of the hovered child object
                childSpriteRenderers[i].color = new Color(0.282f, 0.831f, 0.016f);
            }
            else
            {
                // Reset the color of non-hovered child objects
                childSpriteRenderers[i].color = originalColors[i];
            }
        }
    }

   
}
