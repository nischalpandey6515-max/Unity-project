using UnityEngine;
using UnityEngine.UI;

public class Hazard : MonoBehaviour
{
    [Header("UI Warning")]
    public Canvas warningCanvas;   // Assign in Inspector
    public Text warningText;       // Assign in Inspector
    public string hazardMessage = "⚠️ Hazard Ahead!";

    [Header("Effects")]
    public AudioSource warningSound;   // Optional sound effect
    public bool slowCar = true;        // Toggle car slowdown

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show warning popup
            warningText.text = hazardMessage;
            warningCanvas.enabled = true;

            // Play sound
            if (warningSound != null) warningSound.Play();

            // Slow down car
            if (slowCar)
            {
                CarController car = other.GetComponent<CarController>();
                if (car != null) car.ReduceSpeed();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningCanvas.enabled = false;
        }
    }
}
