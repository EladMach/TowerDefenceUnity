using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    public Vector3 positionOffset;

    private GameObject turret;
    private AudioSource audioSource;
    
    private Renderer rend;

    private GameManager gameManager;
    private BuildManager buildManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

         audioSource = GetComponent<AudioSource>();
        
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("cant build there!");
            return;
        }

        GameObject turretToBuild = buildManager.getTurretToBuild();

        if (gameManager._score >= 2 && turretToBuild == buildManager.standardTurredPrefab)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            audioSource.Play();
            gameManager._score = gameManager._score - 2;
        }
        

        if (gameManager._score >= 4 && turretToBuild == buildManager.level2TurredPrefab)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            audioSource.Play();
            gameManager._score = gameManager._score - 4;
        }       
        else
        {
            turret = null;
        }

    }

    
}
