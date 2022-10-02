// This second example changes the GameObject's color to red when the mouse hovers over it
// Ensure the GameObject has a MeshRenderer

using UnityEngine;

public class OnMouseOverColor : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color mouseOverColor = Color.blue;

    //This stores the GameObject’s original color
    Color originalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer meshRenderer;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        meshRenderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        originalColor = meshRenderer.material.color;
    }

    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        meshRenderer.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        meshRenderer.material.color = originalColor;
    }
}