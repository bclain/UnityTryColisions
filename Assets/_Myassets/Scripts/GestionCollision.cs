using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    private GestionJeu _gestionJeu;
    private bool _touche;
    // Start is called before the first frame update
    void Start()
    {
        _touche = false;
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        if (!_touche && collision.gameObject.tag == "Player"){
            _touche = true;
            GetComponent<MeshRenderer>().material.color = Color.red;
            _gestionJeu.AugmenterPointage();
        }

    }
}
