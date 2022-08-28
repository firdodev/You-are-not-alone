using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator camAnim;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            isCutsceneOn = true;
            camAnim.SetBool("cutscene1", true);
            // Switches back to main player cam after a 3 second delay
            Invoke(nameof(StopCutscene), 3f);
        }
    }
    void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject);
    }
}
