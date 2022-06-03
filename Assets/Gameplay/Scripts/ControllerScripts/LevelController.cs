using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class LevelController : MonoBehaviour
{
    private static LevelController instance;

    public static LevelController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelController>();
            }

            return instance;
        }
    }

    ProgressData curProgress;
    GameObject curLevel, prefabLevel, levelTemplate ,levelEdit;

    [SerializeField]
    int level;

    void Start()
    {
        curProgress = LevelDataSystem.LoadProgressData();
        level = int.Parse(curProgress.level);
        prefabLevel = Resources.Load<GameObject>(Constants.LEVELPATH + curProgress.level);
        ReloadLvl();
    }

    private void Update()
    {
        UIController.Instance.UpdateLevelTXt(level);
    }

    public void NextLvl()
    {
        Destroy(curLevel);
        InputHandler.ResetCurDir();
        level++;
        UIController.Instance.ResetUI();
        prefabLevel = Resources.Load<GameObject>(Constants.LEVELPATH + level.ToString());
        curLevel = Instantiate(prefabLevel);
    }

    // Update is called once per frame
    public void ReloadLvl()
    {
        Destroy(curLevel);
        InputHandler.ResetCurDir();
        prefabLevel = Resources.Load<GameObject>(Constants.LEVELPATH + level.ToString());
        curLevel = Instantiate(prefabLevel);
    }

    private void OnApplicationQuit()
    {
        curProgress.level = level.ToString();
        LevelDataSystem.SaveProgressData(curProgress);
    }


    public void DrawLevel()
    {
        levelTemplate = Resources.Load<GameObject>(Constants.LEVELTEMPLATEPATH);
        levelEdit = Instantiate(levelTemplate);
    }
    
    public void SaveLevel()
    {
        PrefabUtility.SaveAsPrefabAsset(levelEdit,Constants.RESOURCESFOLDER + Constants.LEVELPATH + level.ToString() + Constants.PREFABEXTENSION, out bool success);
        if (success == true)
        {
            Debug.Log("Level " + level.ToString() + " was created successfully");
            if (levelEdit != null)
                DestroyImmediate(levelEdit);
        }
        else
            Debug.Log("Level " + level.ToString() + " failed to create");
    }

    public void ResetLevelData()
    {
        LevelDataSystem.ResetData();
    }
}
