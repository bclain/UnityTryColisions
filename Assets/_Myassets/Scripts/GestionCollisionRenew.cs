using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollisionRenew : MonoBehaviour
{
    private GestionJeu _gestionJeu;
    private bool _touche;
    private Color _couleurInitiale;
    private float _tempsAttente = 4f;
    private float _tempsEcoule;

    void Start()
    {
        _touche = false;
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _couleurInitiale = GetComponent<MeshRenderer>().material.color;
        _tempsEcoule = 0f;
    }

    void Update()
    {
        if (_touche)
        {
            _tempsEcoule += Time.deltaTime;
            if (_tempsEcoule >= _tempsAttente)
            {
                _touche = false;
                GetComponent<MeshRenderer>().material.color = _couleurInitiale;
                _tempsEcoule = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_touche && collision.gameObject.tag == "Player")
        {
            _touche = true;
            GetComponent<MeshRenderer>().material.color = Color.red;
            _gestionJeu.AugmenterPointage();
        }
    }
}