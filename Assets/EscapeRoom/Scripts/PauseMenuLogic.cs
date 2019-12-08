using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Prefabs.Locomotion.Teleporters;
using Zinnia.Data.Type;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuLogic : MonoBehaviour
{
    public TeleporterFacade teleporter;
    public Transform playArea;
    public Transform headOrientation;
    public Transform pauseLocation;
    public Transform gameLocation;

    public Transform Player;
    public GameManager GameManager;

    public List<GameObject> pauseItems;
    public List<GameObject> gameItems;

    public void Start(){
        foreach (GameObject item in pauseItems) {
            item.SetActive(true);
        }

        foreach (GameObject item in gameItems) {
            item.SetActive(false);
        }
    }

    public void StartGame() {
        TransformData teleportDestination = new TransformData(gameLocation);
        Player.Rotate(new Vector3(0, 180, 0), Space.Self);
        teleporter.Teleport(teleportDestination);

        foreach (GameObject item in pauseItems) {
            item.SetActive(false);
        }

        foreach (GameObject item in gameItems) {
            item.SetActive(true);
        }

        GameManager.StartAudio();
    }

    public void ResetGame() {
        TransformData teleportDestination = new TransformData(pauseLocation);
        Player.Rotate(new Vector3(0, 180, 0), Space.Self);
        teleporter.Teleport(teleportDestination);

        foreach (GameObject item in pauseItems) {
            item.SetActive(true);
        }

        foreach (GameObject item in gameItems) {
            item.SetActive(false);
        }
    }
}
