using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameControl : MonoBehaviour
{
   
    public bool gameOver = false;
  
    // Update is called once per frame
    void Update()
    {
        
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
