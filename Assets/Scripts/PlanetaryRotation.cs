using UnityEngine;

public class PlanetaryRotation : MonoBehaviour
{
    public float roationSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime, Space.Self);
    }
}
