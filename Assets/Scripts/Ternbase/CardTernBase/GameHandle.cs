using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameHandle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    HealthSystem playerhealthSystem;
    HealthSystem enemyhealthSystem;
    public Animator Player;
    public Animator Enemy;
    public TMP_Text text;
    public GameObject Popup;
    [SerializeField] public Sprite[] spritesLV1;
    [SerializeField] public Sprite[] spritesLV2;
    [SerializeField] public Sprite[] spritesLV3;
    public Sprite box;
    public List<Button> btns = new List<Button>();

    private bool firstSelect, secondSeclect;
    private int firstSelectIndex, secondSeclectIndex;
    private string firstSelectPuzzle, secondSeclectPuzzle;

    public List<Button> monitors = new List<Button>();
    [SerializeField] public TMP_Text box1;
    [SerializeField] public TMP_Text box2;
    [SerializeField] public TMP_Text box3;

    private int actionCount = 0;
    private void Start()
    {
        SetUpTernbase();
        GetMonitors();
        GetButtons();
        AddListeners();
    }

    void SetUpTernbase(){
        Popup.SetActive(false);
        playerhealthSystem = new HealthSystem(100);
        enemyhealthSystem = new HealthSystem(100);
        playerHealthBar.Setup(playerhealthSystem);
        enemyHealthBar.Setup(enemyhealthSystem);
    }

    void GetMonitors(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Monitor");

        for (int i = 0; i < objects.Length ; i++)
        {
            monitors.Add(objects[i].GetComponent<Button>());
        }
    }

    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length ; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
        }
    }

    //Add event to buttons
    void AddListeners(){
        foreach (Button btn in btns)
        {
            int randomIndex = Random.Range(0, spritesLV1.Length);
            btn.onClick.AddListener(() => PickAPuzzle());
            btn.GetComponent<Image>().sprite = spritesLV1[randomIndex];
        }

        foreach (Button monitor in monitors)
        {
            monitor.onClick.AddListener(() => PlayBack());
        }
    }

    void PlayBack(){
        int Index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(6));
        monitors[Index].image.sprite = box;
        btns[secondSeclectIndex].image.color = new Color (1,1,1,1);
        if(actionCount > 0) actionCount--;
    }

    void PickAPuzzle(){

        if(!firstSelect){

            firstSelect = true;

            firstSelectIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(8));

            firstSelectPuzzle = btns[firstSelectIndex].GetComponent<Image>().sprite.name;

            //btns[firstSelectIndex].interactable = false;
            Debug.Log("firstSelectPuzzle : " + firstSelectPuzzle);

        }else if(!secondSeclect){

            secondSeclect = true;

            secondSeclectIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(8));

            secondSeclectPuzzle = btns[secondSeclectIndex].GetComponent<Image>().sprite.name;
            Debug.Log("secondSeclectPuzzle : " + secondSeclectPuzzle);


            if(firstSelectPuzzle == secondSeclectPuzzle && firstSelectIndex != secondSeclectIndex){
                if(firstSelectPuzzle.Substring(11) == "42"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[0];
                }else if(firstSelectPuzzle.Substring(11) == "43"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[1];
                }else if(firstSelectPuzzle.Substring(11) == "44"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[2];
                }else if(firstSelectPuzzle.Substring(11) == "45"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[3];
                }else if(firstSelectPuzzle.Substring(11) == "28"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[0];
                }else if(firstSelectPuzzle.Substring(11) == "29"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[1];
                }else if(firstSelectPuzzle.Substring(11) == "30"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[2];
                }else if(firstSelectPuzzle.Substring(11) == "31"){
                    btns[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[3];
                }

                Debug.Log("win");
                firstSelect = false;
                secondSeclect = false;
                btns[secondSeclectIndex].interactable = false;
                btns[secondSeclectIndex].image.color = new Color (0,0,0,0);

                if(actionCount == 0){
                    box1.text = "Merge";
                }else if(actionCount == 1){
                    box2.text = "Merge";
                }else{
                    box3.text = "Merge";
                }

                if(actionCount < 3) actionCount++;
                else actionCount = 0;

            }else if(firstSelectPuzzle == secondSeclectPuzzle && firstSelectIndex == secondSeclectIndex){
                monitors[actionCount].image.sprite = btns[firstSelectIndex].image.sprite;
                if(actionCount < 3) actionCount++;
                else actionCount = 0;
                firstSelect = false;
                secondSeclect = false;
                btns[secondSeclectIndex].interactable = false;
                btns[secondSeclectIndex].image.color = new Color (0,0,0,0);

            }else{
                Debug.Log("lose");
                firstSelect = false;
                secondSeclect = false;
            }
            btns[firstSelectIndex].interactable = true;
        }


    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && playerhealthSystem.GetHealth() != 0 && enemyhealthSystem.GetHealth() != 0){
            playerAttack();
            if(enemyhealthSystem.GetHealth() != 0) enemyAttack();
        }
        //Player.SetBool("Attack",false);
    }

    public void playerAttack(){
        //Player.SetBool("Attack",true);
        float randomFloat = Random.Range(0.0f, 1.0f);
        enemyhealthSystem.Damage((int)(randomFloat*50));
        StartCoroutine(waiter());
        if(enemyhealthSystem.GetHealth() == 0){
            Popup.SetActive(true);
            text.text = "Player Win..";
            enemy.SetActive(false);
        }
    }

    public void enemyAttack(){
        float randomFloat = Random.Range(0.0f, 1.0f);
        playerhealthSystem.Damage((int)(randomFloat*50));
        if(playerhealthSystem.GetHealth() == 0){
            Popup.SetActive(true);
            text.text = "Player Dead..";
            player.SetActive(false);
        }
    }

    IEnumerator waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);
    }

}
