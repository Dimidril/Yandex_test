using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float attractionForce = 2f;

    private Rigidbody2D _rigidbody;
    private Coroutine _routine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Game.Instance.AddScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _routine = StartCoroutine(Attract(player.transform));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            StopCoroutine(_routine);
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator Attract(Transform target)
    {
        while (true)
        {
            Vector3 direction = target.position - transform.position;
            _rigidbody.AddForce(direction.normalized * attractionForce);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}