using System.Collections.Generic;
using UnityEngine;

public class DialogQueue
{
    private Queue<string> dlgQueue = new Queue<string>();

    public void RecordDialog(string text)
    {
        dlgQueue.Enqueue(text);
    }

    public string GetDialog()
    {
        return dlgQueue.Dequeue();

    }

    public bool TextQueued()
    {
        return dlgQueue.Count > 0;
    }
}
