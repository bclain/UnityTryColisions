using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HautBasRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _rotationSpeedZ = 0.5f;
    [SerializeField] private float _amplitude = 45f; // L'amplitude de l'oscillation
    [SerializeField] private float _frequency = 1f; // La fréquence de l'oscillation

    private float _angleZ = 0f;

    // Update is called once per frame
    void Update()
    {
        _angleZ = Mathf.Sin(Time.time * _frequency) * _amplitude;

        transform.rotation = Quaternion.Euler(0f, 0f, _angleZ);

        transform.Rotate(0f, 0f, _rotationSpeedZ);
    }
}