using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class ObjectSpawnManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHit = new List<ARRaycastHit>();
    public List<GameObject> levels;
    private GameObject currentLevel;
    private int levelIndex = -1;
    [SerializeField]private GameObject spawnedObject;
    // Start is called before the first frame update
    void Start()
    {
        LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);
            if (raycastManager.Raycast(touch.position, raycastHit))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    
                    spawnedObject.transform.position = raycastHit[0].pose.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (spawnedObject != null)
                    {
                        spawnedObject.transform.position = raycastHit[0].pose.position;
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {

                }
            }
        }
    }

    public void LoadNextLevel()
    {
        Destroy(currentLevel);
        if (levelIndex > levels.Count - 2)
        {
            levelIndex = 0;
            currentLevel = Instantiate(levels[0]);
        }
        else
        {
            levelIndex++;
            currentLevel = Instantiate(levels[levelIndex]);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
