using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmenu : MonoBehaviour
{
   public void OpenLevel(int levelId)
   {
      string levelname = "Level " + levelId; //refer the level by its name
      SceneManager.LoadScene(levelname);
   }
}
