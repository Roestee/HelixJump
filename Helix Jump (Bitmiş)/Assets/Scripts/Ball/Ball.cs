using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject splashPrefabs;
    [SerializeField] private Vector3 splashOffset;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision col)
    {
        rb.velocity = Vector3.up * jumpForce;

        GameObject splash = Instantiate(splashPrefabs, transform.position + splashOffset, transform.rotation);

        splash.transform.SetParent(col.transform);

        string materialName = col.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Unsafe Color (Instance)")
        {
            gameManager.FailLevel();
        }
        else if(materialName == "Last Ring (Instance)")
        {
            PlayerPrefs.SetInt("isStart", 1);
            gameManager.NextLevel();
        }
    }
}
