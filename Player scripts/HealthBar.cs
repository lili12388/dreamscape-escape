using UnityEngine;
using UnityEngine.UI;

public class GoblinHealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider
    public Transform goblin; // Reference to the goblin's transform
    public Vector3 offset; // Offset to position the health bar above the goblin's head

    void Update()
    {
        // Update the health bar's position to follow the goblin
        if (goblin != null)
        {
           healthSlider.transform.position = Vector3.Lerp(healthSlider.transform.position,Camera.main.WorldToScreenPoint(goblin.position + offset),Time.deltaTime * 10f);
        }
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health; // Update the slider's value
    }
}