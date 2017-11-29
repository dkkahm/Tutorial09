using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControllerAlert : DialogController {
    public Text LabelText;
    public Text LabelMessage;

    DialogDataAlert Data
    {
        get;
        set;
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        DialogManager.Instance.Register(DialogType.Alert, this);
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        if(!(data is DialogDataAlert))
        {
            Debug.LogError("Invalid dialog data!");
            return;
        }

        Data = data as DialogDataAlert;
        LabelText.text = Data.Title;
        LabelMessage.text = Data.Message;
    }

    public void OnClickOk()
    {
        if(Data != null && Data.Callback != null)
        {
            Data.Callback();

            DialogManager.Instance.Pop();
        }
    }
}
