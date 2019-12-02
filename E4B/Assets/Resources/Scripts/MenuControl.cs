using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public static MenuControl instance;

    //Outlets
    public GameObject mainMenu;
    public bool isPaused;
    public GameObject chacter; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        instance = this;
        isPaused = true;
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true); 
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        chacter.GetComponent<Rigidbody2D>().gravityScale = 1.25f;
        isPaused = false;
    }

    public void Show()
    {
        ShowMainMenu();
        gameObject.SetActive(true);
    }
}
