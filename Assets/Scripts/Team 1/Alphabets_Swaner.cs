using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabets_Swaner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Alphabets;
    public static int ind;
    private GameObject SpawnedAlphabets;

    private int randomIndex;
    private int randomSide;
    public static bool flag = false;
    [SerializeField]
    private Transform leftPos, rightPos;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Awake()
    {
        Alphabets[0].SetActive(true);
        Alphabets[1].SetActive(true);
        Alphabets[2].SetActive(true);
        Alphabets[3].SetActive(true);
        Alphabets[4].SetActive(true);
        Alphabets[5].SetActive(true);
    }
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }
    IEnumerator SpawnMonsters()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            randomIndex = Random.Range(0, Alphabets.Length);

            randomSide = Random.Range(0, 2);

            SpawnedAlphabets = Instantiate(Alphabets[randomIndex]);
            if (randomSide == 0)
            {
                SpawnedAlphabets.transform.position = leftPos.position;
                // SpawnedAlphabets.GetComponent<Monstar>().speed = Random.Range(4, 10);
            }
            else
            {
                SpawnedAlphabets.transform.position = rightPos.position;
                // SpawnedAlphabets.GetComponent<Monstar>().speed = -Random.Range(4, 10);
                // SpawnedAlphabets.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            Alphabets[ind].SetActive(false);
            flag = false;
        }
    }
}
