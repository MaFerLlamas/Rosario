using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialoguePrologue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string targetSceneName = "PrologoExitCut";


    [SerializeField, TextArea(4,6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private bool didDialogueEnd;
    private int lineIndex;

    DanielaIdentify Daniela;
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1")){
            if (!didDialogueStart && !didDialogueEnd){
                startDialogue();
            }else if (dialogueText.text == dialogueLines[lineIndex]){
                nextDialogueLine();
            }else {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    private void startDialogue(){
            didDialogueStart = true;
            dialoguePanel.SetActive(true);
            dialogueMark.SetActive(false);
            lineIndex = 0;
            Time.timeScale = 0f;
            StartCoroutine(ShowLine());
    }

    private void nextDialogueLine(){
        lineIndex++;
        if (lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }else {
            //END OF CONVERSATION 
            didDialogueStart = false;
            didDialogueEnd = true;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            FindObjectOfType<MorganController>().morganShouldMove = false;
            LoadTargetScene();   
        }
    }

    public void LoadTargetScene()
    {
        // Store the name of the current scene.
        //string currentSceneName = SceneManager.GetActiveScene().name;

        //Destruir antigua Daniela para que funcione la animacion
        //Destroy(GameObject.Find("DanielaTempPrologue"));
        // Load the target scene.
        //SceneManager.LoadScene(targetSceneName);

        Rigidbody2D danielaRigidbody;
        Daniela = FindObjectOfType<DanielaIdentify>();
        danielaRigidbody=Daniela.GetComponent<Rigidbody2D>();
        danielaRigidbody.velocity = new Vector2(5.0f, 0);
        FindObjectOfType<MorganController>().morganShouldMove = true;

        // Store the name of the scene to return to.
        //PlayerPrefs.SetString("PreviousScene", currentSceneName);
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text  += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
