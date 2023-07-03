using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaController : MonoBehaviour
{
    public float initialSpeed = 1f;
    public float accelerationRate = 0.1f;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        currentSpeed += accelerationRate * Time.deltaTime;
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Fucked");
        }
    }
}

