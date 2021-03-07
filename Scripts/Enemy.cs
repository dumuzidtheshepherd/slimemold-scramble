using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private Rigidbody2D _rb;
    private Player _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<Player>();
        _rb = GetComponent<Rigidbody2D>();
        if (!_target.IsDead())
        {
            _rb.velocity = (_target.transform.position - transform.position).normalized * Random.Range(minSpeed, maxSpeed);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_target.IsDead())
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
