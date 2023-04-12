using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    private bool _enPause;
    private GestionJeu _gestionJeu;
    
    void Start()
    {
         _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtAccrochages.text =  _gestionJeu.GetPointage().ToString();
        Time.timeScale = 1;
        _enPause = false;
        _menuPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float temps = Time.time - _gestionJeu.GetTempsDepart();
        _txtTemps.text =  temps.ToString("f2");
        _txtAccrochages.text =  _gestionJeu.GetPointage().ToString();
        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }

    public void ChargerMainMenu()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(0);
    }

}
