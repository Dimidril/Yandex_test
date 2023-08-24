using UnityEngine;


public class SpaceObject : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.left * Game.Instance.speed * Time.deltaTime);
    }
}