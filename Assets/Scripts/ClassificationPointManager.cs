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
    /// ���������莆���X�|�[�������郁�\�b�h
    /// </summary>
    public void CompletedLettersSpown()
    {
        Instantiate(CompletedLetters[0], this.transform.position, Quaternion.identity);
    }
}
