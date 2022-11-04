using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenuManage : MonoBehaviour
{

    public InputField nameInput;
    public Text warning;

  private void Awake()
  {
    warning.enabled = false;
  }

  public void StartNew()
  {
    if (nameInput.text == "")
    {
      Debug.Log("no input");
      warning.enabled = true;
    }
    else
    {
      warning.enabled = false;
      PersistanceManager.Instance.CurrentSessionPlayerName = nameInput.text;
      SceneManager.LoadScene(1);
    }
    
  }
}
