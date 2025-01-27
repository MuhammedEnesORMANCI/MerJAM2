using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public Transform CameraTransform;
    [SerializeField] private float smoothValue = 1f;
    [SerializeField] private float distance = 1f;
    public List<OpenScene> openScenes = new List<OpenScene>();


    private void Awake()
    {
        foreach (var item in openScenes)
        {
            item.Button.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(item.SceneName);
            });
        }
    }

    private void LateUpdate()
    {
        var mousePos = Input.mousePosition;
        float width = UnityEngine.Screen.width;
        float height = UnityEngine.Screen.height;
        var x = ((mousePos.x / width) * distance) - (distance / 2);
        var y = ((mousePos.y / height) * distance) - (distance / 2);
        CameraTransform.localPosition = Vector3.Lerp(CameraTransform.localPosition, new Vector3(x, y, CameraTransform.localPosition.z), smoothValue * Time.deltaTime);
    }
}
[System.Serializable]
public class OpenScene
{
    public Button Button;
    public string SceneName;
}