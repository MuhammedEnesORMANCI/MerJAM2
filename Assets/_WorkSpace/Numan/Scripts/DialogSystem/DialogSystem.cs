using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public float smoothValue = 0.05f;
    [Space]
    [SerializeField] Animator grandmaAnimator;
    [SerializeField] Animator mycharacterAnimator;
    [Space]
    [SerializeField] string grandmaName;
    [SerializeField] string mycharacterName;
    [Space]
    [SerializeField] AudioSource grandmaAudioSource;
    [SerializeField] AudioSource mycharacterAudioSource;
    [Space]
    [Space]
    [SerializeField] List<Camera> cameras = new();
    [Space]
    [SerializeField] private Button openGameButton;
    [SerializeField] private string sceneName;

    [Space]
    [TextArea]
    public List<string> Dialogs = new();

    public int counter;
    private void Awake()
    {
        openGameButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

    public void OpenRandomCamera()
    {
        foreach (var item in cameras)
        {
            item.gameObject.SetActive(false);
        }
        cameras[Random.Range(0, cameras.Count)].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter >= Dialogs.Count && isFinish)
            {
                if (counter > Dialogs.Count)
                {
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    openGameButton.gameObject.SetActive(true);
                    Text.text = "";
                    counter++;
                }
            }
            else
            {
                if (isFinish)
                {
                    NextDialogPrint();
                }
                else
                {
                    CurrentDialogFastPrint();
                }
            }
        }
    }


    public void NextDialogPrint()
    {
        Text.text = "";
        StopAllCoroutines();
        StartCoroutine(printEnumerator(Dialogs[counter]));
        if (Dialogs[counter].Contains(grandmaName))
        {
            grandmaAnimator.SetBool("isTalking", true);
            grandmaAudioSource.Play();
            grandmaAudioSource.pitch = Random.Range(0.9f, 1f);
        }
        else if (Dialogs[counter].Contains(mycharacterName))
        {
            mycharacterAnimator.SetBool("isTalking", true);
            mycharacterAudioSource.Play();
            mycharacterAudioSource.pitch = Random.Range(1f, 1.1f);
        }
        OpenRandomCamera();
    }
    public void CurrentDialogFastPrint()
    {
        Text.text = "";
        StopAllCoroutines();
        Text.text += Dialogs[counter];

        if (Dialogs[counter].Contains(grandmaName))
        {
            grandmaAnimator.SetBool("isTalking", false);
            grandmaAudioSource.Stop();
        }
        else if (Dialogs[counter].Contains(mycharacterName))
        {
            mycharacterAnimator.SetBool("isTalking", false);
            mycharacterAudioSource.Stop();
        }

        counter++;
        isFinish = true;
    }

    private bool isFinish = true;
    IEnumerator printEnumerator(string str)
    {
        isFinish = false;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '<')
            {
                for (int j = 0; j < 15; j++)
                {
                    Text.text += str[i + j];
                }
                i += 15;
            }
            Text.text += str[i];
            yield return new WaitForSeconds(smoothValue);
        }
        if (Dialogs[counter].Contains(grandmaName))
        {
            grandmaAnimator.SetBool("isTalking", false);
            grandmaAudioSource.Stop();
        }
        else if (Dialogs[counter].Contains(mycharacterName))
        {
            mycharacterAnimator.SetBool("isTalking", false);
            mycharacterAudioSource.Stop();
        }

        counter++;
        isFinish = true;
        if (counter >= Dialogs.Count)
        {
            openGameButton.gameObject.SetActive(true);
        }
    }
}
