using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandlingScript : MonoBehaviour
{
    [SerializeField] GameObject[] mainMenuItems;
    [SerializeField] Image imagePreview;
    [SerializeField] Sprite[] stagePreviews;
    [SerializeField] Button nextButton;
    [SerializeField] Button prevButton;

    [SerializeField] GameObject[] pages;

    int sceneNumber;

    int pageNumber;

    private void Start() {
        imagePreview.color = Color.black;
        foreach(GameObject go in mainMenuItems) {
            go.SetActive(false);
        }
    }

    public void StartGame() {
        mainMenuItems[0].SetActive(true);
    }

    public void Instructions() {
        mainMenuItems[1].SetActive(true);
        pageNumber = 0;
        CyclePages();
    }

    public void Credits() {
        mainMenuItems[2].SetActive(true);
    }

    public void PlayGame() {
        SceneManager.LoadScene(sceneNumber);
    }

    public void InstructionsNext() {
        pageNumber++;
        CyclePages();
    }

    public void InstructionsPrev() {
        pageNumber--;
        CyclePages();
    }

    private void CyclePages() {
        for (int i = 0; i < pages.Length; i++) {
            if (i == pageNumber) {
                pages[i].SetActive(true);
            }
            else {
                pages[i].SetActive(false);
            }
        }
        if (pageNumber == 0) {
            prevButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
        else if (pageNumber == 1) {
            prevButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
    }

    public void MainMenu() {
        for(int i = 0;i < mainMenuItems.Length;i++) {
            mainMenuItems[i].SetActive(false);
        }
    }

    public void TwoPlayers() {
        sceneNumber = 1;
        ShowPreview();
    }

    public void ThreePlayers() {
        sceneNumber = 2;
        ShowPreview();
    }

    public void FourPlayers() {
        sceneNumber = 3;
        ShowPreview();
    }

    public void ShowPreview() {
        imagePreview.sprite = stagePreviews[sceneNumber - 1];
        imagePreview.color = Color.white;
    }

    public void ExitGame() {
        Application.Quit(0);
    }
}
