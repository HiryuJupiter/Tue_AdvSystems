
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

[RequireComponent(typeof(SceneLoader))]
public class MainMenuManager : MonoBehaviour
{
    SceneLoader sceneLoader;
    const int Level_Ragdoll = 1;
    const int Level_Grey1 = 2;
    const int Level_Grey2 = 3;

    //MainMenuState state = MainMenuState.MainMenu;

    //Class reference
    GameManager gm;
    SfxManager sfxManager;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        sfxManager = SfxManager.instance;

        gm = GameManager.Instance;
    }

    #region Public - Main menu
    public void StartRagdoll()
    {
        sceneLoader.LoadLevel(Level_Ragdoll);
    }

    public void StartGrey1()
    {
        sceneLoader.LoadLevel(Level_Grey1);
    }

    public void StartGrey2()
    {
        sceneLoader.LoadLevel(Level_Grey2);
    }

    public void ContinueGame()
    {
        gm.loadeSaveFile = true;
        gm.GameData.LoadGameData();
        UnityEngine.SceneManagement.SceneManager.LoadScene(gm.GameData.gameLevelIndex);
    }

    public void Clicked_Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #endregion
}