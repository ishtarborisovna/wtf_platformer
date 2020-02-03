using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public GameObject Zastav;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        HarryControl harry = collider.GetComponent<HarryControl>();

        if (harry && !Zastav.activeInHierarchy)
        {
            TriggerDialog();
        }
    }
}
