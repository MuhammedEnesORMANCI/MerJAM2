using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    [Header("StateTransforms")]
    public Transform SittingTransform;
    public Transform SleepingTransform;
    public Transform EatingTransform;

    [Header("Grandma")]
    public Grandma Grandma;

    [Header("Fly")]
    public GameObject Fly;


    [Header("DeathAnimationObjects")]
    public GameObject HitSwatterAnimationObject;

    [Header("Sounds")]
    [SerializeField] private AudioClip OpenDoorAudioSource;
    [SerializeField] private AudioClip CloseDoorAudioSource;

    [SerializeField] private Button tryAgainButton;

    [SerializeField] private Image InfoImage;


    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;

        tryAgainButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            InfoImage.gameObject.SetActive(!InfoImage.gameObject.activeSelf);
        }
    }

    public void HitSwatter()
    {
        Grandma.gameObject.SetActive(false);

        Grandma.GrandmaStateController.currentState?.ExitState(Grandma);
        if (Grandma.GrandmaStateController.currentState is not null) { Grandma.GrandmaStateController.currentState.Isbreak = true; }
        Grandma.GrandmaStateController.currentState = null;

        //Time.timeScale = 0f;
        GameCamera.gameObject.SetActive(false);
        HitSwatterAnimationObject.SetActive(true);
        HitSwatterAnimationObject.transform.position = Fly.transform.position;

        Vector3 direction = (Fly.transform.position - (Grandma.transform.position + (Vector3.up * 1.5f))).normalized;
        HitSwatterAnimationObject.transform.forward = direction;

        Fly.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Fly.GetComponent<Rigidbody>().useGravity = true;

        Fly.GetComponent<Animator>().Play("DieSlap");
        Fly.GetComponent<FlyController>().enabled = false;
        tryAgainButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OpenDoorSound()
    {
        var t = new GameObject();
        var a = t.AddComponent<AudioSource>();
        a.clip = OpenDoorAudioSource;
        a.Play();
        Destroy(t, 1f);
    }
    public void CloseDoorSound()
    {
        var t = new GameObject();
        var a = t.AddComponent<AudioSource>();
        a.clip = OpenDoorAudioSource;
        a.Play();
        Destroy(t, 1f);
    }
}
