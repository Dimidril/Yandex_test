using UnityEngine;

public class Barier : MonoBehaviour
{
    public float speed = 1.0f; // The speed of the movement
    public float distance = 1.0f; // The distance the object moves up and down

    private float initialY;

    private void Start() {
        initialY = transform.position.y;
    }

    private void Update() {
        float newY = Mathf.Sin(Time.time * speed) * distance;
        transform.Translate(0, newY - transform.position.y + initialY, 0);
    }
}