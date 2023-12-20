using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartrGame : MonoBehaviour
{
    public RuntimeAnimatorController firstAnim;
    public RuntimeAnimatorController secondAnim;
    public GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {
        gameObj.GetComponent<Animator>().runtimeAnimatorController = firstAnim;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void StratGame11()
    {

        SceneManager.LoadScene(1);
        gameObj.GetComponent<Animator>().runtimeAnimatorController = secondAnim;

    }
}
