using UnityEngine;

public class SelectSlot : MonoBehaviour
{
    public GameObject[] slots;
    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        slots = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
            spriteRenderers = slots[i].GetComponentsInChildren<SpriteRenderer>();
        }
    }

    private void OnMouseEnter()
    {
        // Change the color of each slot to the hover color
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.color = Color.green;
        }
    }
}
