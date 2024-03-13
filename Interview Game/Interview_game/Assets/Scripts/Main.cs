using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public FuncCardManager GetCardManager;
    public FuncFight GetFuncFight;

    public GameObject pausePanel;

    public Text inputNameText;
    public TextMeshPro playerNameText;

    void Start()
    {
        pausePanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            StartButton();
        }
    }

    public void StartButton()
    {
        GetCardManager.Reset();
        GetFuncFight.Reset();

        pausePanel.SetActive(false);
        playerNameText.text = inputNameText.text;

        StartCoroutine(GetCardManager.CardActive());
    }
}