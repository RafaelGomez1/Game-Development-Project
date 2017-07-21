using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour {


    //Este metodo solo lo ejecuta unity  si un collider de tipo 2D entra
    //en contacto con el prefab asigando, (muy util para ataques)
    //Ejemplo, Gancho de Kold, etiquetado con X nombre, si entra en
    //contacto con plataforma Y se ejecuta el fragmento de codigo.
    void OnTriggerEnter2D(Collider2D theObject)
    {
        if (theObject.tag == "Player")
        {
            PlayerControl.sharedInstance.KillPlayer();
        }
    }

}
