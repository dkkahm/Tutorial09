using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogType
{
    Alert,
    Confirm,
    Ranking
}

public sealed class DialogManager {
    List<DialogData> _dialogQueue;
    Dictionary<DialogType, DialogController> _dialogMap;
    DialogController _currentDialog;
    private static DialogManager instance = new DialogManager();

    public static DialogManager Instance
    {
        get
        {
            return instance;
        }
    }

    private DialogManager()
    {
        _dialogQueue = new List<DialogData>();
        _dialogMap = new Dictionary<DialogType, DialogController>();
    }

    public void Register(DialogType type, DialogController controller)
    {
        _dialogMap[type] = controller;
    }

    public void Push(DialogData data)
    {
        _dialogQueue.Add(data);

        if(_currentDialog == null)
        {
            ShowNext();
        }
    }

    public void Pop()
    {
        if(_currentDialog != null)
        {
            _currentDialog.Close(
                delegate
                {
                    _currentDialog = null;

                    if (_dialogQueue.Count > 0)
                    {
                        ShowNext();
                    }
                }
            );
        }
    }

    private void ShowNext()
    {
        DialogData next = _dialogQueue[0];
        DialogController controller = _dialogMap[next.Type].GetComponent<DialogController>();
        _currentDialog = controller;
        _currentDialog.Build(next);
        _currentDialog.Show(delegate { });
        _dialogQueue.RemoveAt(0);
    }

    public bool IsShowing()
    {
        return _currentDialog != null;
    }
}
