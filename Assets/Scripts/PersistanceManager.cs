using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
  public static PersistanceManager Instance;
  public string CurrentSessionPlayerName;
  public string HighScorePlayerName;
  public int HighScore;

  private void Awake()
  {
    // start of new code
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);

    LoadHighScore();
  }

  [System.Serializable]
  class SaveData
  {
    public string HighScorePlayerName;
    public int HighScore;
  }

  public void SaveHighScore()
  {
    SaveData data = new SaveData();
    data.HighScorePlayerName = HighScorePlayerName;
    data.HighScore = HighScore;

    string json = JsonUtility.ToJson(data);

    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
  }

  public void LoadHighScore()
  {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      SaveData data = JsonUtility.FromJson<SaveData>(json);

      HighScorePlayerName = data.HighScorePlayerName;
      HighScore = data.HighScore;
    }
  }
}
