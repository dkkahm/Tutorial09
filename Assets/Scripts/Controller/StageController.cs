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

        StartCoroutine(ShowAlert());
    }

    public void AddPoint(int Point)
    {
        StagePoint += Point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        Debug.Log("FinishGame");

        DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Restart?", delegate (bool yn)
        {
            if (yn)
            {
                Debug.Log("OK Pressed");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Debug.Log("Cancel Pressed");
                SceneManager.LoadScene("Lobby");
            }
        });

        DialogManager.Instance.Push(confirm);
    }

    IEnumerator ShowAlert()
    {
        yield return new WaitForEndOfFrame();

        DialogDataAlert alert = new DialogDataAlert("START", "Game Start!", delegate ()
        {
            Debug.Log("OK Pressed");
        });

        DialogManager.Instance.Push(alert);
    }
}
