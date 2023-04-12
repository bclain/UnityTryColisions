using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinPartie : MonoBehaviour
{

    private bool _finPartie = false;
    private GestionJeu _gestionJeu;
    private Player _player;
    private float _tempsTotal = 0;
    private float _accrochages = 0;
    private float _pointage = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie) 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green; 
            _finPartie = true; 
            int noScene = SceneManager.GetActiveScene().buildIndex; 
            if (noScene == (SceneManager.sceneCountInBuildSettings - 1)) 
            {
                 _gestionJeu.SetNiveau3(_gestionJeu.GetPointage() - (_gestionJeu.GetAccrochagesNiv1()+_gestionJeu.GetAccrochagesNiv2()), Time.time - (_gestionJeu.GetTempsNiv1()+_gestionJeu.GetTempsNiv2()));
              
                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();  //Calcul le temps total pour le niveau 1
                float tempsTotalniv2 = _gestionJeu.GetTempsNiv2() + _gestionJeu.GetAccrochagesNiv2(); // Calcul le temps total pour le niveau 2
                float tempsTotalniv3 =_gestionJeu.GetTempsNiv3() + _gestionJeu.GetAccrochagesNiv3();// Calcul le temps total pour le niveau 3

                // Affichage des r�sultats finaux dans la console
                Debug.Log("Fin de partie !!!!!!!");

                Debug.Log("Le temps pour le niveau 1 est de : " + _gestionJeu.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");

                Debug.Log("Le temps pour le niveau 2 est de : " + _gestionJeu.GetTempsNiv2().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 2 : " + _gestionJeu.GetAccrochagesNiv2() + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");

                Debug.Log("Le temps pour le niveau 3 est de : " + _gestionJeu.GetTempsNiv3().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 3 : " + _gestionJeu.GetAccrochagesNiv3() + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");

                Debug.Log("Le temps total pour les trois niveau est de : " + (tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3).ToString("f2") + " secondes");
                _tempsTotal = tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3;
        
                _player.finPartieJoueur();  // Appeler la m�thode publique dans Player pour d�sactiver le joueur
            }
            else
            {
                if(noScene == 0 ){
                    // Appelle la m�thode publique dans gestion jeu pour conserver les informations du niveau 1
                    _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                }
                if(noScene == 1 ){
                    // Appelle la m�thode publique dans gestion jeu pour conserver les informations du niveau 1
                    _gestionJeu.SetNiveau2(_gestionJeu.GetPointage() - _gestionJeu.GetAccrochagesNiv1(), Time.time - _gestionJeu.GetTempsNiv1());
                }

                // Charge la sc�ne suivante
                SceneManager.LoadScene(noScene + 1);            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
