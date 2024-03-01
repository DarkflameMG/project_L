using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]private Animator transition;
    [SerializeField]private float transitionTime = 0.5f;

    // private void Update() {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         LoadMission();
    //     }
    // }
    public void LoadMission()
    {
        StartCoroutine(LoadMap(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadMap(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

    public Animator GetAnimator()
    {
        return transition;
    }
}
