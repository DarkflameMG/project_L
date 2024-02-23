using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    private int waitting = 0;

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
                Debug.Log(action.Peek());


            }
            //merge fail
            else
            {
                Debug.Log("lose");

            }
            firstSelect = false;
            secondSeclect = false;
        }

    }

    private void Update()
    {
        // if (battle)
        // {
        //     top.SetActive(false);
        //     bot.SetActive(false);
        //     startBtn.interactable = false;
        //     boxStartBtn.SetActive(false);
        // }
        // else
        // {
        //     top.SetActive(true);
        //     bot.SetActive(true);
        //     startBtn.interactable = true;
        //     boxStartBtn.SetActive(true);
        // }
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
        Debug.Log("deck : " + deck.Count);

        //add new card
        for (int i = newDeck.Count; i < 5; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spritesLV1.Length);
            deck[i].GetComponent<Image>().sprite = spritesLV1[randomIndex];
        }
        Debug.Log("deck : " + deck.Count);

        //open all card
        for (int i = 0; i < deck.Count; i++)
        {
            Debug.Log("open card :" + i + 1);
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

        if (!skip)
        {
            for (int i = 0; i < action.Count; i++)
            {

                if (action.Pop() == "use")
                {
                    switch (actionSprite[actionSprite.Count - 1].name)
                    {
                        //LV_1
                        case "andLv1_0":
                            dmg += 10;
                            skill = "1";
                            yield return new WaitForSeconds(1);
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "orLv1_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal(10);
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        case "notLv1_0":
                            yield return new WaitForSeconds(1); 
                            dmg += 10;
                            skill = "0";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "nandLv1_0":
                            yield return new WaitForSeconds(1); 
                            dmg += 15;
                            skill = "3";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "norLv1_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal(15);
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        case "xorLv1_0":
                            yield return new WaitForSeconds(1);
                            dmg += dmg*0.05;
                            PlayerAnimation.Play("buff", 0, 0f);
                            waitting += 1;
                            break;
                        case "xnorLv1_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal((int)(200*0.15));
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        //Lv_2
                        case "andLv2_0":
                            yield return new WaitForSeconds(1);
                            dmg += 25;
                            skill = "1";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "orLv2_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal(25);
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        case "notLv2_0":
                            yield return new WaitForSeconds(1);
                            dmg += 15;
                            skill = "0";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "nandLv2_0":
                            yield return new WaitForSeconds(1);
                            dmg += 30;
                            skill = "3";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "norLv2_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal(30);
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        case "xorLv2_0":
                            yield return new WaitForSeconds(1);
                            dmg += dmg*0.1;
                            PlayerAnimation.Play("buff", 0, 0f);
                            waitting += 1;
                            break;
                        case "xnorLv2_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal((int)(200*0.35));
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        //Lv_3
                        case "andLv3_0":
                            yield return new WaitForSeconds(1);
                            dmg += 55;
                            skill = "1";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "orLv3_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal(55);
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        case "notLv3_0":
                            yield return new WaitForSeconds(1);
                            dmg += 25;
                            skill = "0";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "nandLv3_0":
                            yield return new WaitForSeconds(1);
                            dmg += 60;
                            skill = "3";
                            StartCoroutine(playerAttackAnimation(dmg, skill));
                            waitting += 1;
                            dmg = 10;
                            break;
                        case "norLv3_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal(60);
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                        case "xorLv3_0":
                            yield return new WaitForSeconds(1);
                            dmg += dmg*0.2;
                            PlayerAnimation.Play("buff", 0, 0f);
                            waitting += 1;
                            break;
                        case "xnorLv3_0":
                            yield return new WaitForSeconds(1);
                            playerhealthSystem.Heal((int)(200*0.8));
                            PlayerAnimation.Play("acquire", 0, 0f);
                            waitting += 1;
                            break;
                    }
                    actionSprite.RemoveAt(actionSprite.Count - 1);
                }
                else
                {
                    actionSprite.RemoveAt(actionSprite.Count - 1);
                    actionSprite.RemoveAt(actionSprite.Count - 1);
                }
            }

            reTurn();

            if(waitting == 0) skip = true;

        }
        else
        {
            reTurn();
            action.Clear();
            actionSprite.Clear();
        }

    }

    void startTern()
    {
        StartCoroutine(waitForPlayer());
    }

    IEnumerator waitForPlayer()
    {
        battle = true;
        StartCoroutine(playerAction());
        // SetBtnActive(deck, false);
        yield return new WaitForSeconds(3);
        StartCoroutine(enemyAttack());
        skip = false;
        // SetBtnActive(deck, true);
    }

    IEnumerator enemyAttack()
    {
        if (enemyhealthSystem.GetHealth() > 0)
        {
            if (!skip)
            {
                yield return new WaitForSeconds(waitting);
                waitting = 0;
            }
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
    }

    IEnumerator playerAttackAnimation(double dmg, string skill)
    {
        // PlayerAnimation.Play("attack", 0, 0f);
        Vector3 posPlayer = GameObject.Find("Player").transform.localPosition;
        Vector3 posEnemy = GameObject.Find("Enemy").transform.localPosition;
        GameObject.Find("Player").transform.localPosition = new Vector3(posEnemy.x - 3, posPlayer.y, posPlayer.z);
        if (skill == "1")
        {
            PlayerAnimation.Play("skill1", 0, 0f);
        }
        else if (skill == "2")
        {
            PlayerAnimation.Play("skill2", 0, 0f);
        }
        else if (skill == "3")
        {
            PlayerAnimation.Play("skill3", 0, 0f);
        }else{
            PlayerAnimation.Play("attack", 0, 0f);
        }
        EnemyAnimation.Play("Hurt", 0, 0f);
        enemyhealthSystem.Damage((int)dmg);
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").transform.localPosition = posPlayer;
        StartCoroutine(checkGameEnd());
    }

    IEnumerator checkGameEnd()
    {
        bool check = false;
        Debug.Log("Player HP : " + playerhealthSystem.GetHealth());
        Debug.Log("Enemy HP : " + enemyhealthSystem.GetHealth());
        if (enemyhealthSystem.GetHealth() == 0)
        {
            check = true;
            EnemyAnimation.Play("Death", 0, 0f);
            yield return new WaitForSeconds(1);
            Popup.SetActive(true);
            text.text = "Player Win..";
            GameObject.Find("Enemy").SetActive(false);
        }
        if (playerhealthSystem.GetHealth() == 0)
        {
            check = true;
            PlayerAnimation.Play("Death", 0, 0f);
            yield return new WaitForSeconds(1);
            Popup.SetActive(true);
            text.text = "Player Dead..";
            GameObject.Find("Player").SetActive(false);
        }

        if (!skip)
        {
            yield return new WaitForSeconds(2);
        }
        else
        {
            yield return new WaitForSeconds(1);
        }
        if (!check) battle = false;
    }

}
