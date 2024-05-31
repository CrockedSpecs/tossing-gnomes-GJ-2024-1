using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Listas serializadas para editar desde el inspector de Unity
    [SerializeField] private List<Sprite> levelSprites; // Sprites para cada nivel
    [SerializeField] private List<string> names; // Nombres para cada nivel
    [SerializeField] private List<Vector4> stats; // Estad�sticas para cada nivel

    public int level = 0; // Nivel actual

    // M�todo que se llama cuando se hace clic en el objeto
    void OnMouseDown()
    {
        // Incrementa el nivel si la tecla "W" est� presionada
        if (Input.GetKey("w"))
        {
            level++;
        }
        // Decrementa el nivel si la tecla "S" est� presionada
        if (Input.GetKey("s"))
        {
            level--;
        }

        // Asegura que el nivel est� dentro de los l�mites de las listas
        level = Mathf.Clamp(level, 0, levelSprites.Count - 1);
    }

    // M�todo para obtener el sprite correspondiente al nivel actual
    Sprite GetTurretSprite()
    {
        return levelSprites[level];
    }

    // M�todo para obtener el nombre correspondiente al nivel actual
    string GetName()
    {
        return names[level];
    }

    // M�todo para obtener las estad�sticas correspondientes al nivel actual
    Vector4 GetStats()
    {
        return stats[level];
    }

    // M�todo que se llama en cada frame
    private void Update()
    {
        // Actualiza el sprite del objeto
        GetComponent<SpriteRenderer>().sprite = GetTurretSprite();
        // Actualiza el nombre del objeto
        gameObject.name = GetName();
    }
}
