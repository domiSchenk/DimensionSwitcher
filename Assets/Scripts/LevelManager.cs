using Cinemachine;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] public int deathCount = 0;
    [SerializeField] public int _diamondCount = 0;
    // [SerializeField] private Transform respawnPoint;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private GameObject _respawnPoint;
    [SerializeField] private TextMeshProUGUI labelDeathCounter;
    [SerializeField] private TextMeshProUGUI labelDiamondCounter;

    
    void Awake()
    {
        instance = this;
        //get gameobject by tag
        _respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        var vcam = GameObject.FindGameObjectWithTag("VCAM");
        _cinemachineVirtualCamera = vcam.GetComponent<CinemachineVirtualCamera>();
        StartGame();
    }

   
    void Update()
    {

    }
    public void StartGame()
    {
        deathCount = 0;
        spawn();
    }

    public void Respawn()
    {
        // if player exists do not spawn
        // if(GameObject.FindGameObjectWithTag("Player") != null) return;
        spawn();
        AddDeathCount();
    }
    private void spawn()
    {
        var player = Instantiate(playerPrefab, _respawnPoint.transform.position, Quaternion.identity);

        var follow = player.GetComponentInChildren<Transform>().Find("Character");
        // player.tag = "PlayerController";
        _cinemachineVirtualCamera.Follow = follow;
        player.SetActive(true);
    }

    public void AddDeathCount()
    {
        deathCount++;
        labelDeathCounter.text = deathCount.ToString();
    }

    public void AddDiamondCount()
    {
        _diamondCount++;
        labelDiamondCounter.text = _diamondCount.ToString();
    }
    public void GameDone()
    {
        // showPanelComplete = true;
        // panelComplete.blocksRaycasts = true;
        // panelComplete.interactable = true;
    }
}
