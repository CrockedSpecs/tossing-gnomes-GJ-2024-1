using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideStorw : MonoBehaviour
{
   bool close = true;
   public GameObject store;

   public void OnButtonClick()
    {
        if (close)
        {
            store.SetActive(true);
            close = false;
        }
        else
        {
            store.SetActive(false);
            close = true;
        }
    }
}
