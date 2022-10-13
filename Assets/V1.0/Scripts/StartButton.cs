using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    private Button button;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartCall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCall()
    {
        gameManager.StartGame();
        gameManager.isGameActive = true;
    }
}
