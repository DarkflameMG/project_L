using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameHandle : MonoBehaviour
{
    public Transform room;
    [SerializeField] GameObject top;
    [SerializeField] GameObject bot;

    private bool battle = false;
    [SerializeField] private GameObject boxStartBtn;
    [SerializeField] private Button startBtn;

    //Monster List
    public List<GameObject> monsters = new List<GameObject>();
    [SerializeField] private MonsterSO monster;

    //characters
    [SerializeField] private GameObject player;
    private HealthBar playerHealthBar;
    private HealthBar enemyHealthBar;
    private HealthSystem playerhealthSystem;
    private HealthSystem enemyhealthSystem;
    private Animator PlayerAnimation;
    private Animator EnemyAnimation;
    private double dmg = 10;

    //Pop up end game
    public TMP_Text text;
    public GameObject Popup;

    //Cards sprites
    [SerializeField] private Sprite[] spritesLV1;
    [SerializeField] private Sprite[] spritesLV2;
    [SerializeField] private Sprite[] spritesLV3;

    // Card blank(back card)
    public Sprite box;

    //Logic Variable
    private bool skip = false;
    private bool firstSelect, secondSeclect;
    private int firstSelectIndex, secondSeclectIndex;
    private string firstSelectPuzzle, secondSeclectPuzzle;
    public Stack<string> action = new Stack<string>();
    public List<Sprite> actionSprite = new List<Sprite>();
    public List<int> actionIndex = new List<int>();

    //Deck
    public List<Button> deck = new List<Button>();
    public List<Sprite> newDeck = new List<Sprite>();

    //Action Box
    public List<Button> monitors = new List<Button>();
    [SerializeField] public TMP_Text box1;
    [SerializeField] public TMP_Text box2;
    [SerializeField] public TMP_Text box3;

    private bool waittingForPlayer = true;
    private bool waittingForEnemy = false;

    private void Start()
    {
        GetMonitors();
        GetButtons();
        SetUpTurnBase();
        AddListeners();
    }

    void SetUpTurnBase()
    {
        Popup.SetActive(false);
        spawnMonster();
        spawnPlayer();
    }

    void spawnMonster()
    {
        foreach (GameObject mon in monsters)
        {
            if (mon.name == monster.monsterName)
            {
                Vector3 position = new Vector3((float)5.11, (float)0.03, (float)-4.778947);
                GameObject e = Instantiate(mon, room);
                e.name = "Enemy";
                e.transform.localPosition = position;
                enemyhealthSystem = new HealthSystem(monster.hp);
                enemyHealthBar = e.GetComponentInChildren<HealthBar>();
                enemyHealthBar.Setup(enemyhealthSystem);
                EnemyAnimation = e.GetComponent<Animator>();
                break;
            }
        }
    }

    void spawnPlayer()
    {
        Vector3 position = new Vector3((float)-5.8, (float)1.49, (float)-4.778947);
        GameObject p = Instantiate(player, room);
        p.name = "Player";
        p.transform.localPosition = position;
        playerhealthSystem = new HealthSystem(100);
        playerHealthBar = p.GetComponentInChildren<HealthBar>();
        playerHealthBar.Setup(playerhealthSystem);
        PlayerAnimation = p.GetComponent<Animator>();
    }

    void GetMonitors()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Monitor");

        for (int i = 0; i < objects.Length; i++)
        {
            monitors.Add(objects[i].GetComponent<Button>());
        }
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            deck.Add(objects[i].GetComponent<Button>());
        }
    }

    //Add event to buttons
    void AddListeners()
    {
        foreach (Button btn in deck)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
            int randomIndex = UnityEngine.Random.Range(0, spritesLV1.Length);
            btn.GetComponent<Image>().sprite = spritesLV1[randomIndex];
            // btn.GetComponent<Animator>().Play("Create", 0, 0f);
        }

        foreach (Button monitor in monitors)
        {
            monitor.onClick.AddListener(() => PlayBack());
        }

        startBtn.onClick.AddListener(() => startTern());
    }

    //undo
    void PlayBack()
    {
        int Index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(6));
        Debug.Log("Index = " + Index);

        monitors[Index].image.sprite = box;

        // undo merge
        if (action.Pop() == "merged")
        {

            Debug.Log("Undo merged");
            Debug.Log("action Index count: " + actionIndex.Count);

            //open second card
            deck[actionIndex[actionIndex.Count - 1]].interactable = true;
            deck[actionIndex[actionIndex.Count - 1]].image.color = new Color(1, 1, 1, 1);

            // return card to deck
            deck[actionIndex[actionIndex.Count - 2]].GetComponent<Image>().sprite = actionSprite[actionSprite.Count - 2];
            deck[actionIndex[actionIndex.Count - 1]].GetComponent<Image>().sprite = actionSprite[actionSprite.Count - 1];

            //clear list action
            actionSprite.RemoveAt(actionSprite.Count - 1);
            actionSprite.RemoveAt(actionSprite.Count - 1);
            actionIndex.RemoveAt(actionIndex.Count - 1);
            actionIndex.RemoveAt(actionIndex.Count - 1);


            if (Index == 0) box1.text = "";
            if (Index == 1) box2.text = "";
            if (Index == 2) box3.text = "";


        }
        // undo action
        else
        {

            Debug.Log("Undo action card");
            //deck[secondSeclectIndex].GetComponent<Image>().sprite = actionSprite[actionSprite.Count-1];

            //open second card
            deck[actionIndex[actionIndex.Count - 1]].interactable = true;
            deck[actionIndex[actionIndex.Count - 1]].image.color = new Color(1, 1, 1, 1);

            //clear list action
            actionSprite.RemoveAt(actionSprite.Count - 1);
            actionIndex.RemoveAt(actionIndex.Count - 1);
        }

    }

    void SetBtnActive(List<Button> btns, bool value)
    {
        foreach (Button btn in btns)
        {
            btn.interactable = value;
        }
    }
    void PickAPuzzle()
    {
        if (!firstSelect)
        {

            firstSelect = true;

            firstSelectIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(8));

            firstSelectPuzzle = deck[firstSelectIndex].GetComponent<Image>().sprite.name;

            Debug.Log("firstSelectPuzzle : " + firstSelectPuzzle);

        }
        else if (!secondSeclect)
        {

            secondSeclect = true;

            secondSeclectIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(8));
            // name
            secondSeclectPuzzle = deck[secondSeclectIndex].GetComponent<Image>().sprite.name;

            Debug.Log("secondSeclectPuzzle : " + secondSeclectPuzzle);

            //merge
            if (firstSelectIndex != secondSeclectIndex && firstSelectPuzzle == secondSeclectPuzzle && action.Count <= 2)
            {

                action.Push("merged");
                Debug.Log("action : " + action.Peek());


                actionSprite.Add(deck[firstSelectIndex].GetComponent<Image>().sprite);
                actionSprite.Add(deck[secondSeclectIndex].GetComponent<Image>().sprite);
                actionIndex.Add(firstSelectIndex);
                actionIndex.Add(secondSeclectIndex);
                switch (action.Count)
                {
                    case 1:
                        box1.text = "Merged";
                        break;
                    case 2:
                        box2.text = "Merged";
                        break;
                    case 3:
                        box3.text = "Merged";
                        break;
                }

                // card type
                switch (firstSelectPuzzle)
                {
                    //LV_1
                    case "andLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[0];
                        break;
                    case "orLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[1];
                        break;
                    case "notLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[2];
                        break;
                    case "nandLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[3];
                        break;
                    case "norLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[4];
                        break;
                    case "xorLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[5];
                        break;
                    case "xnorLv1_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV2[6];
                        break;
                    //Lv_2
                    case "andLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[0];
                        break;
                    case "orLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[1];
                        break;
                    case "notLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[2];
                        break;
                    case "nandLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[3];
                        break;
                    case "norLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[4];
                        break;
                    case "xorLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[5];
                        break;
                    case "xnorLv2_0":
                        deck[firstSelectIndex].GetComponent<Image>().sprite = spritesLV3[6];
                        break;
                }

                //close second card
                deck[secondSeclectIndex].interactable = false;
                deck[secondSeclectIndex].image.color = new Color(0, 0, 0, 0);


            }
            //use card action
            else if (firstSelectPuzzle == secondSeclectPuzzle && firstSelectIndex == secondSeclectIndex && action.Count <= 2)
            {
                action.Push("use");
                Debug.Log("action : " + action.Peek());

                //change image card to action box
                if (action.Count <= 1) monitors[0].image.sprite = deck[secondSeclectIndex].image.sprite;
                else monitors[action.Count - 1].image.sprite = deck[secondSeclectIndex].image.sprite;

                actionSprite.Add(deck[secondSeclectIndex].GetComponent<Image>().sprite);
                actionIndex.Add(secondSeclectIndex);


                // close second card
                deck[secondSeclectIndex].interactable = false;
                deck[secondSeclectIndex].image.color = new Color(0, 0, 0, 0);
                // Debug.Log(action.Peek());


            }
            //merge fail
            else
            {
                Debug.Log("Card not match!!");

            }
            firstSelect = false;
            secondSeclect = false;
        }

    }

    private void Update()
    {
        if (battle)
        {
            top.SetActive(false);
            bot.SetActive(false);
            startBtn.interactable = false;
            boxStartBtn.SetActive(false);
        }
        else
        {
            top.SetActive(true);
            bot.SetActive(true);
            startBtn.interactable = true;
            boxStartBtn.SetActive(true);
        }
        if (action.Count == 0)
        {
            monitors[0].enabled = false;
            monitors[1].enabled = false;
            monitors[2].enabled = false;
        }
        else if (action.Count == 1)
        {
            monitors[0].enabled = true;
            monitors[1].enabled = false;
            monitors[2].enabled = false;
        }
        else if (action.Count == 2)
        {
            monitors[0].enabled = false;
            monitors[1].enabled = true;
            monitors[2].enabled = false;
        }
        else
        {
            monitors[0].enabled = false;
            monitors[1].enabled = false;
            monitors[2].enabled = true;
        }
    }

    void reTurn()
    {
        actionIndex.Clear();
        actionSprite.Clear();
        action.Clear();

        //reset monitors
        for (int i = 0; i < 3; i++)
        {
            monitors[i].image.sprite = box;
        }

        //reset deck
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i].interactable == true)
            {
                newDeck.Add(deck[i].GetComponent<Image>().sprite);
            }
        }
        deck.Clear();
        Debug.Log("new deck : " + newDeck.Count);
        Debug.Log("deck : " + deck.Count);
        GetButtons();
        for (int i = 0; i < newDeck.Count; i++)
        {
            deck[i].GetComponent<Image>().sprite = newDeck[i];
        }
        // Debug.Log("deck : " + deck.Count);

        //add new card
        for (int i = newDeck.Count; i < 5; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spritesLV1.Length);
            deck[i].GetComponent<Image>().sprite = spritesLV1[randomIndex];
        }
        // Debug.Log("deck : " + deck.Count);

        //open all card
        for (int i = 0; i < deck.Count; i++)
        {
            // Debug.Log("open card :" + i + 1);
            deck[i].interactable = true;
            deck[i].image.color = new Color(1, 1, 1, 1);
        }
        newDeck.Clear();
        box1.text = "";
        box2.text = "";
        box3.text = "";
    }

    IEnumerator playerAction()
    {
        string skill;
        int i = 0;
        if (!skip)
        {
            Debug.Log("Action Count: " + action.Count);
            while (action.Count != 0)
            {
                Debug.Log("waitting loop: " + (i + 1) + " time.");
                Debug.Log("Action " + (i + 1) + " : " + action.Peek());
                if (action.Pop() == "use")
                {
                    switch (actionSprite[actionSprite.Count - 1].name)
                    {
                        //LV_1
                        case "andLv1_0":
                            dmg += 10;
                            skill = "skill1";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "orLv1_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation(10, skill));
                            yield return new WaitForSeconds(1);
                            break;
                        case "notLv1_0":
                            dmg += 10;
                            skill = "0";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1); 
                            dmg = 10;
                            break;
                        case "nandLv1_0":
                            dmg += 15;
                            skill = "skill3";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1); 
                            dmg = 10;
                            break;
                        case "norLv1_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation(15, skill));
                            yield return new WaitForSeconds(1);
                            break;
                        case "xorLv1_0":
                            dmg += dmg * 0.05;
                            PlayerAnimation.Play("buff", 0, 0f);
                            yield return new WaitForSeconds(1);
                            break;
                        case "xnorLv1_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation((int)(200 * 0.15), skill));
                            yield return new WaitForSeconds(1);
                            break;
                        //Lv_2
                        case "andLv2_0":
                            dmg += 25;
                            skill = "skill1";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "orLv2_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation(25, skill));
                            yield return new WaitForSeconds(1);
                            break;
                        case "notLv2_0":
                            dmg += 15;
                            skill = "0";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "nandLv2_0":
                            dmg += 30;
                            skill = "skill3";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "norLv2_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation(30, skill));
                            yield return new WaitForSeconds(1);
                            break;
                        case "xorLv2_0":
                            dmg += dmg * 0.1;
                            skill = "buff";
                            StartCoroutine(playerAttackAnimation(0, skill));
                            yield return new WaitForSeconds(1);
                            break;
                        case "xnorLv2_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation((int)(200 * 0.35), skill));                            
                            yield return new WaitForSeconds(1);
                            break;
                        //Lv_3
                        case "andLv3_0":
                            dmg += 55;
                            skill = "skill1";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "orLv3_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation(55, skill));
                            yield return new WaitForSeconds(1);                        
                            break;
                        case "notLv3_0":
                            dmg += 25;
                            skill = "0";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "nandLv3_0":
                            dmg += 60;
                            skill = "skill3";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            yield return new WaitForSeconds(1);
                            dmg = 10;
                            break;
                        case "norLv3_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation(60, skill));                            
                            yield return new WaitForSeconds(1);                            
                            break;
                        case "xorLv3_0":
                            dmg += dmg * 0.2;
                            skill = "buff";
                            StartCoroutine(playerAttackAnimation(0, skill));
                            yield return new WaitForSeconds(1);
                            break;
                        case "xnorLv3_0":
                            skill = "acquire";
                            StartCoroutine(playerAttackAnimation((int)(200 * 0.8), skill));
                            yield return new WaitForSeconds(1);
                            break;
                    }
                    Debug.Log("End action :" + (i + 1));
                    actionSprite.RemoveAt(actionSprite.Count - 1);
                }
                else
                {
                    Debug.Log("Pop : Merged");
                    actionSprite.RemoveAt(actionSprite.Count - 1);
                    actionSprite.RemoveAt(actionSprite.Count - 1);
                }
                
            }
        }
        
        yield return new WaitForSeconds(1);
        waittingForPlayer = false;
        
    }

    void startTern()
    {
        StartCoroutine(waitForPlayer());
    }

    IEnumerator waitForPlayer()
    {
        battle = true;
        StartCoroutine(playerAction());
        yield return new WaitUntil(() => waittingForPlayer == false);
        StartCoroutine(enemyAttack());
        yield return new WaitUntil(() => waittingForEnemy == false);
        skip = false;
        waittingForPlayer = true;
        if(playerhealthSystem.GetHealth() == 0 || enemyhealthSystem.GetHealth() == 0) battle = true;
        else battle = false;
        yield return new WaitUntil(() => battle == false);
        reTurn();
    }

    IEnumerator enemyAttack()
    {
        waittingForEnemy = true;
        if (enemyhealthSystem.GetHealth() > 0)
        {
            // if (!skip)
            // {
            //     yield return new WaitForSeconds(waitting);
            // }
            Vector3 posPlayer = GameObject.Find("Player").transform.localPosition;
            Vector3 posEnemy = GameObject.Find("Enemy").transform.localPosition;
            GameObject.Find("Enemy").transform.localPosition = new Vector3(posPlayer.x + 3, posEnemy.y, posEnemy.z);
            EnemyAnimation.Play("Attack", 0, 0f);
            PlayerAnimation.Play("hurt", 0, 0f);
            playerhealthSystem.Damage(monster.attack);
            yield return new WaitForSeconds(1);
            GameObject.Find("Enemy").transform.localPosition = posEnemy;
        }
        StartCoroutine(checkGameEnd());
        waittingForEnemy = false;
    }

    IEnumerator playerAttackAnimation(double dmg, string skill)
    {
        Vector3 posPlayer = GameObject.Find("Player").transform.localPosition;
        Vector3 posEnemy = GameObject.Find("Enemy").transform.localPosition;
        // GameObject.Find("Player").transform.localPosition = new Vector3(posEnemy.x - 3, posPlayer.y, posPlayer.z);

        if (skill == "skill1")
        {
            GameObject.Find("Player").transform.localPosition = new Vector3(posEnemy.x - 3, posPlayer.y, posPlayer.z);
            PlayerAnimation.Play("skill1", 0, 0f);
            EnemyAnimation.Play("Hurt", 0, 0f);
            enemyhealthSystem.Damage((int)dmg);
            // yield return new WaitWhile(() => EnemyAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
        }
        else if (skill == "skill2")
        {
            GameObject.Find("Player").transform.localPosition = new Vector3(posEnemy.x - 3, posPlayer.y, posPlayer.z);
            PlayerAnimation.Play("skill2", 0, 0f);
            EnemyAnimation.Play("Hurt", 0, 0f);
            enemyhealthSystem.Damage((int)dmg);
            // yield return new WaitWhile(() => EnemyAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
        }
        else if (skill == "skill3")
        {
            GameObject.Find("Player").transform.localPosition = new Vector3(posEnemy.x - 3, posPlayer.y, posPlayer.z);
            PlayerAnimation.Play("skill3", 0, 0f);
            EnemyAnimation.Play("Hurt", 0, 0f);
            enemyhealthSystem.Damage((int)dmg);
            // yield return new WaitWhile(() => EnemyAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
        }
        else if (skill == "acquire")
        {
            PlayerAnimation.Play("acquire", 0, 0f);
            playerhealthSystem.Heal((int)dmg);
            // yield return new WaitWhile(() => PlayerAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
        }
        else if (skill == "buff")
        {
            PlayerAnimation.Play("buff", 0, 0f);
            // yield return new WaitWhile(() => PlayerAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
        }
        else
        {
            GameObject.Find("Player").transform.localPosition = new Vector3(posEnemy.x - 3, posPlayer.y, posPlayer.z);
            PlayerAnimation.Play("attack", 0, 0f);
            EnemyAnimation.Play("Hurt", 0, 0f);
            enemyhealthSystem.Damage((int)dmg);
            // yield return new WaitWhile(() => EnemyAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
        }
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").transform.localPosition = posPlayer;
        StartCoroutine(checkGameEnd());
    }

    IEnumerator checkGameEnd()
    {
        // bool check = false;
        Debug.Log("Player HP : " + playerhealthSystem.GetHealth());
        Debug.Log("Enemy HP : " + enemyhealthSystem.GetHealth());
        if (enemyhealthSystem.GetHealth() == 0)
        {
            // check = true;
            EnemyAnimation.Play("Death", 0, 0f);
            yield return new WaitForSeconds(1);
            Popup.SetActive(true);
            text.text = "Player Win..";
            GameObject.Find("Enemy").SetActive(false);
        }
        if (playerhealthSystem.GetHealth() == 0)
        {
            // check = true;
            PlayerAnimation.Play("Death", 0, 0f);
            yield return new WaitForSeconds(1);
            Popup.SetActive(true);
            text.text = "Player Dead..";
            GameObject.Find("Player").SetActive(false);
        }

        // if (!skip)
        // {
        //     yield return new WaitForSeconds(2);
        // }
        // else
        // {
        //     yield return new WaitForSeconds(1);
        // }
        // if (!check) battle = false;
    }

}
