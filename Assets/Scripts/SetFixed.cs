using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFixed : MonoBehaviour
{
    public bool fix = false;

    private void Update()
    {
        // Si el objeto no está fijado, actualizar su posición a la posición del ratón
        if (!fix)
        {

            // Obtener la posición del ratón en coordenadas del mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Asegurarse de que la coordenada z sea cero

            // Actualizar la posición del objeto
            transform.position = mousePosition;
        }
    }

    private void OnMouseDown()
    {
        // Obtener el componente SpriteRenderer del objeto
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Si el objeto tiene un SpriteRenderer, cambiar la opacidad a 1.0 y fijar el objeto
            Color color = spriteRenderer.color;
            color.a = 1.0f; // Establecer la opacidad a 100%
            spriteRenderer.color = color;

            // Fijar el objeto
            fix = true;
        }
    }

}
