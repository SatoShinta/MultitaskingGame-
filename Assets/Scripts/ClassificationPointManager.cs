using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassificationPointManager : MonoBehaviour
{
    [SerializeField] GameObject[] CompletedLetters;
    [SerializeField] ClickGameManager ClickGameManager;

    public bool Completed;

    void Start()
    {
       
    }

    void Update()
    {
        ClickGameManager = FindObjectOfType<ClickGameManager>();

        if (Completed == true)
        {
            CompletedLettersSpown();
            Completed = false;
        }
    }

    /// <summary>
    /// 完成した手紙をスポーンさせるメソッド
    /// </summary>
    public void CompletedLettersSpown()
    {
        Instantiate(CompletedLetters[0], this.transform.position, Quaternion.identity);
    }
}
