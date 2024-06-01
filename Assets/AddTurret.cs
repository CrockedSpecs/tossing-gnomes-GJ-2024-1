using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTurret : MonoBehaviour
{
    public GameObject turret; // Prefab de la torreta que se añadirá
    public GameObject blueprint; // Instancia de la torreta en modo blueprint (semi-transparente)

    private Vector3 mousePosition;
    public bool isDragging = false;
    public bool isBlueprint = true;

    private void Start()
    {
        // Crear un nuevo objeto para mostrar el sprite de la torreta en el inspector
        GameObject showThis = new GameObject("Sprite" + gameObject.name);
        showThis.AddComponent<SpriteRenderer>();

        // Asignar el sprite y el color del prefab de la torreta al nuevo objeto
        SpriteRenderer turretRenderer = turret.GetComponent<SpriteRenderer>();
        SpriteRenderer showRenderer = showThis.GetComponent<SpriteRenderer>();

        showRenderer.sprite = turretRenderer.sprite;
        showRenderer.color = turretRenderer.color;
        showRenderer.sortingOrder = 2; // Asegurarse de que el sprite se dibuje sobre otros objetos

        // Configurar el nuevo objeto como hijo del objeto actual
        showThis.transform.SetParent(transform, false);
        showThis.transform.position = transform.position;
    }

    private void OnMouseDown()
    {
        // Si no se está arrastrando, instanciar el blueprint en la posición del ratón
        if (!isDragging)
        {
            // Instanciar el prefab de la torreta
            blueprint = Instantiate(turret, Vector3.zero, Quaternion.identity);

            // Añadir el componente SetFixed al blueprint para manejar su fijación
            blueprint.AddComponent<SetFixed>();

            // Configurar el color del blueprint como semi-transparente
            SpriteRenderer spriteRenderer = blueprint.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = 0.5f; // Hacer semi-transparente
                spriteRenderer.color = color;
            }
        }
    }
}
