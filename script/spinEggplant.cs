using UnityEngine;

public class EggplantSpinner : MonoBehaviour 
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Vector3.up spins the object around its vertical (Y) axis
        // Space.Self ensures it rotates around its own local center
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
