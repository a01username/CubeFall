using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameControl : MonoBehaviour
{
    public float timer = 0f;
    public GameObject winText;
    public bool gameOver = false;
  
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI winTextUI = winText.GetComponent<TextMeshProUGUI>();
        winTextUI.text = "Score/Time: " + timer.ToString("#.00");
        if (!gameOver)
        {
            timer += Time.deltaTime;
        }
        /*else
        { 
            TextMeshProUGUI winTextUI = winText.GetComponent<TextMeshProUGUI>();
            winTextUI.text = "Score/Time: " + timer.ToString("#.00");
        }*/

    }

    public void endGame(){
        gameOver = true;
        StartCoroutine(restart());
    }

    IEnumerator restart(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
