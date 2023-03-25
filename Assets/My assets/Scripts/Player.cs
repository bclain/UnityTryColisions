using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 20f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-14f, 5f, -34f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MouvementJoueur();
    }

    private void MouvementJoueur()
    {
        
        float positionX = Input.GetAxis("Horizontal"); // Déplacement horizontal (gauche/droite)
        float positionZ = Input.GetAxis("Vertical"); // Déplacement vertical (haut/bas)
        Vector3 direction = new Vector3(positionX, 0f, positionZ); // Vecteur de déplacement
        transform.Translate(direction * Time.deltaTime * _vitesse);
    
    }
     public void finPartieJoueur()
    { 
        gameObject.SetActive(false);  // D�sactive le gameObject
    }

}
