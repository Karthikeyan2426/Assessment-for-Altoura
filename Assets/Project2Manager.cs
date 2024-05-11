using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Project2Manager : MonoBehaviour
{
    public GameObject glbObject;
    public GameObject panel;
    public Text panelText;
    private int currentStep = 1;

    void Start()
    {
        panel.SetActive(false);
    }

    public void OnProject2ThumbnailClicked()
    {
        LoadGLBFile();
        DisplayPanel();
    }

    private void LoadGLBFile()
    {
        Instantiate(glbObject, Vector3.zero, Quaternion.identity);
    }

    private void DisplayPanel()
    {
        panel.SetActive(true);
        SetPanelText();
    }

    private void SetPanelText()
    {
        switch (currentStep)
        {
            case 1:
                panelText.text = "Step 1: Display only text";
                break;
            case 2:
                panelText.text = "Step 2: Show text alongside an image";
                break;
            case 3:
                panelText.text = "Step 3: Teleport to the car showroom";
                // Load the TeleportLocationScene asynchronously
                SceneManager.LoadSceneAsync("TeleportLocationScene", LoadSceneMode.Additive).completed += TeleportUser;
                break;
        }
    }

    private void TeleportUser(AsyncOperation operation)
    {
        // Find the teleportation location in the loaded scene
        GameObject teleportLocationObject = GameObject.Find("TeleportLocation");

        // Check if the teleport location exists
        if (teleportLocationObject != null)
        {
            // Teleport the user to the teleportation location (car showroom entrance)
            Camera.main.transform.position = teleportLocationObject.transform.position;
            Camera.main.transform.rotation = teleportLocationObject.transform.rotation;
        }
        else
        {
            Debug.LogError("Teleport Location not found!");
        }

        // Unload the TeleportLocationScene
        SceneManager.UnloadSceneAsync("TeleportLocationScene");
    }

    public void NextStep()
    {
        currentStep = Mathf.Min(currentStep + 1, 3);
        SetPanelText();
    }

    public void BackStep()
    {
        currentStep = Mathf.Max(currentStep - 1, 1);
        SetPanelText();
    }

    public void LoadHomePageScene()
    {
        //Navigates back to the HomePage Scene
        SceneManager.LoadScene("HomePage");
    }
}
