using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour {
    public Transform window;

    public bool Visible
    {
        get
        {
            return window.gameObject.activeSelf;
        }

        protected set
        {
            window.gameObject.SetActive(value);
        }
    }

    IEnumerator OnEnter(Action callback)
    {
        Visible = true;

        if(callback != null)
        {
            callback();
        }

        yield break;
    }

    IEnumerator OnExit(Action callback)
    {
        Visible = false;

        if(callback != null)
        {
            callback();
        }

        yield break;
    }



    public virtual void Build(DialogData data)
    {

    }

    public void Show(Action callback)
    {
        StartCoroutine(OnEnter(callback));
    }

    public void Close(Action callback)
    {
        StartCoroutine(OnExit(callback));
    }
}
