using UnityEngine;

public class SpawnFishManager : MonoBehaviour
{
    [SerializeField] GameObject SpawnFish;
    float spawnWaitTime;
    void Start()
    {
        spawnWaitTime = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnWaitTime <= 0)
        {
            spawnTheFish();
            spawnWaitTime = Random.Range(.3f, 1f);
        }
        else
        {
            spawnWaitTime -= Time.deltaTime;
        }
    }

    void spawnTheFish()
    {
        float rightOrLeft = Random.Range(0f, 2f);
        if(rightOrLeft <= 1f)
        {
            GameObject spawnedFish = Instantiate(SpawnFish, new Vector2(-13f, Random.Range(4f, -4f)), Quaternion.identity);
            Destroy(spawnedFish, 5f);
        }
        else if(rightOrLeft >= 1f)
        {
            Vector3 theScale = SpawnFish.transform.localScale;
            theScale.y *= -1;
            SpawnFish.transform.localScale = theScale;
            GameObject spawnedFish = Instantiate(SpawnFish, new Vector2(13f, Random.Range(4f, -4f)), new Quaternion(transform.rotation.x, transform.rotation.y, 180f, transform.rotation.w));
            theScale.y = -1;
            SpawnFish.transform.localScale = theScale;
            Destroy(spawnedFish, 5f);
            Debug.Log(SpawnFish.transform.localScale);
        }
        
    }
}
