using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControllerConfirm : DialogController
{
    public Text LabelText;
    public Text LabelMessage;

    DialogDataConfirm Data
    {
        get;
        set;
    }

    private void Awake()
    {
        DialogManager.Instance.Register(DialogType.Confirm, this);
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        if(!(data is DialogDataConfirm))
        {
            Debug.LogError("Invalid dialog data!");
            return;
        }

        Data = data as DialogDataConfirm;
        LabelText.text = Data.Title;
        LabelMessage.text = Data.Message;
    }

    public void OnClickOk()
    {
        if(Data.Callback != null)
        {
            Data.Callback(true);
        }

        Debug.Log("OnClickOk");

        DialogManager.Instance.Pop();
    }

    public void OnClickCancel()
    {
        if(Data.Callback != null)
        {
            Data.Callback(false);
        }

        DialogManager.Instance.Pop();
    }
}
