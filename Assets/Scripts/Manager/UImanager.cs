using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UImanager : MonoBehaviour
{
    private Canvas m_activeCanvas;

    public Button startButton;

    private void Start()
    {
        Assert.IsNotNull(startButton);
        startButton.onClick.AddListener(StartApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartApp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
