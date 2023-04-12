using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class FinMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private TMP_Text _txtPointage = default;
    private GestionJeu _gestionJeu;

 // Start is called before the first frame update
    void Start()
    {
       _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtAccrochages.text =  _gestionJeu.GetAccrochagesFinal().ToString();
        _txtPointage.text =  _gestionJeu.GetPointage().ToString();
        float temps = _gestionJeu.GetTempsFinal();
        _txtTemps.text =  temps.ToString("f2"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChargerMenu()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(0);
    }

        public void Quitter()
    {
        Application.Quit();
    }


   
}