using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Project1Manager : MonoBehaviour
{
    public RawImage videoDisplay;
    private VideoPlayer videoPlayer;
    private AssetBundle assetBundle;
    private string assetBundlePath = Application.streamingAssetsPath + "/assetbundlecola";

    void Start()
    {
        // Checking if the asset bundle is already loaded
        if (assetBundle == null)
        {
            // Loading the asset bundle containing the video
            assetBundle = AssetBundle.LoadFromFile(assetBundlePath);
            if (assetBundle == null)
            {
                Debug.LogError("Failed to load asset bundle!");
                return;
            }
        }

        // Loading the video clip from the asset bundle
        VideoClip videoClip = assetBundle.LoadAsset<VideoClip>("ColaVideo");
        if (videoClip == null)
        {
            Debug.LogError("Failed to load video from asset bundle!");
            return;
        }

        // Create a new Video Player
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        // Sets the video clip to the Video Player
        videoPlayer.clip = videoClip;

        // Sets the video to play on a Render Texture
        RenderTexture renderTexture = new RenderTexture((int)videoClip.width, (int)videoClip.height, 24);
        videoPlayer.targetTexture = renderTexture;
        videoDisplay.texture = renderTexture;

        // Play the video
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        // Pause the video
        videoPlayer.Pause();
    }

    public void StopVideo()
    {
        // Stop the video
        videoPlayer.Stop();
    }

    private void OnDestroy()
    {
        // Unload the asset bundle when the object is destroyed
        if (assetBundle != null)
        {
            assetBundle.Unload(true);
        }
    }

    public void LoadHomePageScene()
    {
        //Navigates back to the HomePage Scene
        SceneManager.LoadScene("HomePage");
    }
}
