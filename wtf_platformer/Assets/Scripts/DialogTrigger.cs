using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        HarryControl harry = collider.GetComponent<HarryControl>();

        if (harry)
        {
            TriggerDialog();
        }
    }
}
