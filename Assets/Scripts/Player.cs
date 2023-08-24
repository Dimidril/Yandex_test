using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float force;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Fly(bool isUp)
    {
        Vector2 dir = isUp ? Vector2.up : Vector2.down;
        _rigidbody.AddForce(dir * force, ForceMode2D.Force);
    }

    public void Death()
    {
        Debug.Log("Died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddCoin()
    {
        
    }
}