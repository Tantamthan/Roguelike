using UnityEngine;

public class SpawmEntity : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyprefab;
    [SerializeField]
    private float minimunmSpawmTime;
    [SerializeField]

    private float maximumSpawmTime;
    private float spawmTime;


    void Awake()
    {
        setTimeUntiSpawm();
    }

    // Update is called once per frame
    void Update()
    {
        spawmTime -= Time.deltaTime;
        if(spawmTime <= 0)
        {
            Instantiate(enemyprefab, transform.position, Quaternion.identity);
            setTimeUntiSpawm();
        }
    }
    private void setTimeUntiSpawm()
    {
        spawmTime = Random.Range(minimunmSpawmTime, maximumSpawmTime);
    }
}
