using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestEngine : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    public Color activeColor;
    public QuestEngine[] allQuests;
    public Color currentColor;
    public QuestArrow questArrow;
    private void  Start() {
        {
            allQuests = FindObjectsOfType<QuestEngine>();
            currentColor = questItem.color;
        }
    }
    // public QuestArrow questArrow;

    private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.tag  == "Player")
         {
            FinishQuest();
            Destroy(gameObject);
         }
    }
    void FinishQuest() {
        questItem.GetComponent<Button>().interactable = false;
        currentColor = completedColor;
        questItem.color = completedColor;
        // questArrow.gameObject.SetActive(false);
    }
    public void OnQuestClick ()
    {
        // questArrow.gameObject.SetActive(true);
       //  questArrow.target = this.transform;
       
        foreach(QuestEngine quest in allQuests)
            {
                quest.questItem.color = currentColor;
            }
        questItem.color = activeColor;
    }
}
