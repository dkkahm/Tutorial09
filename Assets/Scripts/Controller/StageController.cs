using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
    public static StageController Instance;
    public int StagePoint = 0;
    public Text PointText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoint(int Point)
    {
        StagePoint += Point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("Lobby");
    }
}
