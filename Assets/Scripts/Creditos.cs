using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //escnea prologo Casa Daniela
    [SerializeField] Sprite MasTarde;
    //escena Final
    [SerializeField] Sprite pensamientos1;
    [SerializeField] Sprite pensamientos2;
    [SerializeField] Sprite pensamientos3;
    [SerializeField] Sprite pensamientosFinal;
    [SerializeField] Sprite creditos1;
    [SerializeField] Sprite creditos2;
    [SerializeField] Sprite creditosFinal;

    private float darkness;
    private float clarity;
    private bool dark;

    private float timer;
    private int segundosEntreFrame =4;
    // Start is called before the first frame update

    void Start()
    {
        dark = false;
        clarity = 0;
        darkness = 0;
        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, darkness);

        timer = 0.0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = pensamientos1;

        spriteRenderer.sprite = Environment.algoQueHacerVisitsDone() ? pensamientos1 : MasTarde;
    }

    // Update is called once per frame
    void Update()
    {
        if (Environment.dialogoDanielaFinalDone || Environment.prologoCasaDanielaDialogo2EscenasDone && !Environment.prologoCasaDaniela4PM)
        {
            this.transform.position = new Vector2(Environment.morgan.transform.position.x, Environment.morgan.transform.position.y);
            if (darkness < 255f && !dark)
            {
                darkness += 100 * Time.deltaTime;
                this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, darkness / 255);
            }
            else if (dark && clarity < 254)
            {
                clarity += 100 * Time.deltaTime;
                this.GetComponent<Renderer>().material.color = new Color(clarity / 255, clarity / 255, clarity / 255, darkness / 255);
            }
            if (darkness > 254)
            {
                dark = true;
                //obscuridad = 0;
            }
            if (clarity > 254 && Environment.dialogoDanielaFinalDone)
            {
                timer += Time.deltaTime / segundosEntreFrame; //modificar este valor para incrementar segundos entre frame
                if (timer > 1.0f && timer < 2.0f)
                {
                    Debug.Log(timer);
                    spriteRenderer.sprite = pensamientos2;
                }else if(timer > 2.0f && timer < 3.0f)
                {
                    spriteRenderer.sprite = pensamientos3;

                }else if (timer > 3.0f && timer < 4.0f)
                {
                    spriteRenderer.sprite = pensamientosFinal;

                }else if (timer > 4.0f && timer < 5.0f)
                {
                    spriteRenderer.sprite = creditos1;

                }else if (timer > 5.0f && timer < 6.0f) { 
                    spriteRenderer.sprite = creditos2;

                }else if(timer >= 6.0f && timer < 7.0f)
                {
                    spriteRenderer.sprite = creditosFinal;
                }
            }
            else if (clarity > 254)
            {
                //cambiar escnea
                Environment.prologoCasaDaniela4PM = true;
                Environment.newSpawnName = "WC";
                UnityEngine.SceneManagement.SceneManager.LoadScene("PrologoCasaDaniela");
                 // Activando el sistema de misiones por primera vez
                FindObjectOfType<GlobalCanvasManager>().scrollView.SetActive(true);
                //Mostrando Mision en pantalla
                // "UN PRETEXTO"
                //QUEST 0 INICIO
                FindObjectOfType<QuestDialogue>().initQuest(0, true, false);
            }
        }
    }
}
