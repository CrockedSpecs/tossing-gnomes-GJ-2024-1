using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonToTorret : MonoBehaviour
{
    public static ChangeButtonToTorret sharedInstanceChangeButtonToTorret;

    public GameObject punto;

    public GameObject Torreta;
    public GameObject Cañon;
    //GameObject punto;



    public int buttonNumber;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (sharedInstanceChangeButtonToTorret == null)
        {
            sharedInstanceChangeButtonToTorret = this;
        }
    }

    public void changeAsset()
    {
        if (buttonNumber == 0)
        {
            Instantiate(Torreta, 
                new Vector3(punto.transform.position.x
                ,punto.transform.position.y
                ,punto.transform.position.z)
                , Quaternion.identity);
            Destroy(punto);
        }
        else if(buttonNumber == 1)
        {
            Instantiate(Cañon,
                new Vector3(punto.transform.position.x
                , punto.transform.position.y
                , punto.transform.position.z)
                , Quaternion.identity);
            Destroy(punto);
        }
        else if (buttonNumber == 2)
        {

        }
    }
}
