using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using TMPro;
using UnityEngine;

public class FuncEndGame : MonoBehaviour
{
    public Main GetMain;
    public FuncFight GetFuncFight;
    public TextMeshProUGUI EndText;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        EndText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetFuncFight.round >= 10)
        {
            //Debug.Log("end");
            if (GetFuncFight.Model.transform.position.x < 0)
            {
                EndText.text = "You Win.";
            }else
            {
                EndText.text = "You Lose.";
            }
            GetMain.pausePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LEndWall")
        {
            EndText.text = "You Win.";
        }
        else if (other.gameObject.tag == "LEndWall")
        {
            EndText.text = "You Lose.";
        }
        Debug.Log("end");
        GetMain.pausePanel.SetActive(true);
    }
}