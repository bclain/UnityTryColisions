using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    // ***** Attributs *****

    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    private int _accrochageNiveau1 = 0;  // Attribut qui conserve le nombre d'accrochage pour le niveau 1
    private float _tempsNiveau1 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1
    private int _accrochageNiveau2 = 0;  // Attribut qui conserve le nombre d'accrochage pour le niveau 2
    private float _tempsNiveau2 = 0.0f;  // Attribut qui conserve le temps pour le niveau 2
    private int _accrochageNiveau3 = 0;  // Attribut qui conserve le nombre d'accrochage pour le niveau 3
    private float _tempsNiveau3 = 0.0f;  // Attribut qui conserve le temps pour le niveau 3
    private float _tempsDepart = 0;
    private float _tempsFinal = 0;
    private float _accrochagesFinal = 0;
    
    // ***** Méthodes privées *****
    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante.
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        InstructionsDepart();  // Affiche les instructions de départ
        _tempsDepart = Time.time;
    }

    /*
     * Méthode qui affiche les instructions au départ
     */
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course D'obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque contact avec un obstable entraînera une pénalité");
        Debug.Log("");
    }

    // ***** Méthodes publiques ******

    /*
     * Méthode publique qui permet d'augmenter le pointage de 1
     */
    public void AugmenterPointage()
    {
        _pointage++;
    }

    // Accesseur qui retourne la valeur de l'attribut pointage
    public int GetPointage()
    {
        return _pointage;
    }

     // M�thode qui re�oit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau1(int accrochages, float tempsNiv)
    {
        _accrochageNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiv;
    }
     // M�thode qui re�oit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau2(int accrochages, float tempsNiv)
    {
        _accrochageNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiv;
    }
     // M�thode qui re�oit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau3(int accrochages, float tempsNiv)
    {
        _accrochageNiveau3 = accrochages;
        _tempsNiveau3 = tempsNiv;
    }

    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv1()
    {
        return _tempsNiveau1;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv1()
    {
        return _accrochageNiveau1;
    }

    // Accesseur qui retourne le temps pour le niveau 2
    public float GetTempsNiv2()
    {
        return _tempsNiveau2;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 2
    public int GetAccrochagesNiv2()
    {
        return _accrochageNiveau2;
    }

    // Accesseur qui retourne le temps pour le niveau 3
    public float GetTempsNiv3()
    {
        return _tempsNiveau3;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 3
    public int GetAccrochagesNiv3()
    {
        return _accrochageNiveau3;
    }

        public float GetTempsDepart()
    {
        return _tempsDepart;
    }

    public float GetTempsFinal()
    {
        _tempsFinal = _tempsNiveau1 + _tempsNiveau2 + _tempsNiveau3;
        return _tempsFinal;
    }
    
    public float GetAccrochagesFinal()
    {
        _accrochagesFinal = _accrochageNiveau1 + _accrochageNiveau2 + _accrochageNiveau3;
        return _accrochagesFinal;
    }
}