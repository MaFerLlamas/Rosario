using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialoguePrologue : MonoBehaviour
{
    [SerializeField] private AudioClip npcVoice;
    [SerializeField] private AudioClip playerVoice;
    [SerializeField] private float typingTime;
    [SerializeField] private int charsToPlaySound;
    [SerializeField] private bool isPlayerTalking;


    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;


    [SerializeField, TextArea(4,6)] private string[] dialogueLines;


    private AudioSource audioSource;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private bool didDialogueEnd;
    private int lineIndex;

    private Animator animator;
    string horizontal = "Horizontal";


    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = npcVoice;
    }

   
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
        //SceneManager.LoadScene(targetSceneName); //scene change removed for a new script for player movement

        Rigidbody2D danielaRigidbody;
        DanielaIdentify Daniela;
        animator.SetFloat(horizontal,1);
        Daniela = FindObjectOfType<DanielaIdentify>();
        danielaRigidbody=Daniela.GetComponent<Rigidbody2D>();
        danielaRigidbody.velocity = new Vector2(5.0f, 0);
        FindObjectOfType<MorganController>().morganShouldMove = true;
        GoToNewPlace newPlace = FindObjectOfType<GoToNewPlace>();
        newPlace.isActive = true;

        // Store the name of the scene to return to.
        //PlayerPrefs.SetString("PreviousScene", currentSceneName);
    }

    private void SelectAudioClip()
    {
        if(lineIndex !=0)
        {
        isPlayerTalking = !isPlayerTalking;
        }

        audioSource.clip = isPlayerTalking ? playerVoice : npcVoice;
    }

    private IEnumerator ShowLine()
    {
        SelectAudioClip();
        dialogueText.text = string.Empty;
    int charIndex = 0;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text  += ch;

            if(charIndex % charsToPlaySound == 0){
                audioSource.Play();
            }

            audioSource.Play();
            charIndex++;
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
