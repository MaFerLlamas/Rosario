using UnityEngine;

public class CambiarSprite : MonoBehaviour
{
    public Sprite nuevoSprite; // Asigna el nuevo sprite en el inspector
    public int vecesParaCambio = 1;

    private int contadorClicks = 0;

    void Update()
    {
        // Detecta clics del mouse solo cuando se produce el clic
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Verifica si el clic ocurrió en este objeto
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Clic en el objeto.");
                contadorClicks++;

                if (contadorClicks >= vecesParaCambio)
                {
                    CambiarSpriteActual();
                    contadorClicks = 0;
                }
            }
        }
    }

    void CambiarSpriteActual()
    {
        if (nuevoSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = nuevoSprite;
        }
        // Puedes agregar más lógica aquí según tus necesidades
    }
}
