using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiege : MonoBehaviour
{
    [SerializeField] private GameObject _piege = default;
    [SerializeField] private float _intensiteForce = 500;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    { 
        _rb = _piege.GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other){
        _rb.useGravity = true;
        _rb.AddForce(Vector3.down * _intensiteForce);
    }
}
