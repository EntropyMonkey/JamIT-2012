using UnityEditor;
using UnityEngine;

class LevelGenerator : MonoBehaviour
{
    public Camera GameCamera;
    public GameObject platformPrefab;
	public GameObject bananaPrefab;
    public GameObject halfpipePrefab;
    public GameObject rampPrefab;
    private Vector3 StartPos;
    private Vector3 EndPos;

    public float PlatformSize = 2F;  //GO size = size * 2
    public float HalfpipeSize = 2F;
    public float RampSize = 2F;

    void Start()
    {
		GameCamera = Camera.main;
        StartPos = GameCamera.transform.position;
        EndPos = StartPos;
        EndPos += new Vector3(0, -2, 0);
        EndPos.Scale(new Vector3(1, 1, 0));
        
        for (int i = 0; i < 4; i++)
        {   
            SpawnPlatform(EndPos + Vector3.down * 4);
            EndPos += new Vector3(PlatformSize, 0, 0);
        }
    }

    void Update()
    {
        if(GameCamera.transform.position.x + 20 > EndPos.x)
        {
            int r = Random.Range(0, 8);
            if (r == 0) //Spawn single platform
            {
				SpawnPlatform(EndPos + Vector3.down * 5);
                EndPos += new Vector3(PlatformSize, 0, 0);
                EndPos += new Vector3(Random.RandomRange(1F, 3F), 0, 0);
                PossiblySpawnBanana(EndPos);
			}
            if (r == 1) //Spawn two platforms
            {
                SpawnPlatform(EndPos + Vector3.down * 5);
                EndPos += new Vector3(PlatformSize, 0, 0);
                SpawnPlatform(EndPos + Vector3.down * 5);
                EndPos += new Vector3(PlatformSize, 0, 0);
                EndPos += new Vector3(Random.RandomRange(1F, 3F), 0, 0);
                PossiblySpawnBanana(EndPos);
            }
            else if (r == 2) //Spawn halfpipe
            {
                SpawnHalfpipe(EndPos + Vector3.down * 6f);
                EndPos += new Vector3(HalfpipeSize, 0, 0);
                EndPos += new Vector3(Random.RandomRange(1F, 3F), 0, 0);
                PossiblySpawnBanana(EndPos);
            }
            else if (r == 3) //Spawn ramp
            {
                SpawnRamp(EndPos + Vector3.down * 2);
                EndPos += new Vector3(RampSize, 0, 0);
                EndPos += new Vector3(Random.RandomRange(1F, 3F), 0, 0);
                PossiblySpawnBanana(EndPos);
            }
            else if (r == 4) //Spawn space
            { 
				SpawnPlatform(EndPos + Vector3.down * 5);
                EndPos += new Vector3(PlatformSize, 0, 0);
                EndPos += new Vector3(Random.RandomRange(1F, 3F), 0, 0);
                PossiblySpawnBanana(EndPos);
            }
            else if (r == 5) //Spawn small empty room
            {
                EndPos += new Vector3(Random.RandomRange(1F, 3F), 0, 0);
                PossiblySpawnBanana(EndPos);
            }
            else if (r == 6) //Spawn medium space
            {
                SpawnPlatform(EndPos + Vector3.down * 5);
                EndPos += new Vector3(PlatformSize, 0, 0);
                EndPos += new Vector3(Random.RandomRange(3F, 6F), 0, 0);
                PossiblySpawnBanana(EndPos);
            }
            else if (r == 7 ) //Spawn space ramp and banana
            {
                Vector3 rampPos = EndPos + Vector3.down * -Random.RandomRange(2F, 1F);
                SpawnRamp(rampPos);
                SpawnBanana(rampPos + Vector3.up * Random.RandomRange(2F,4F) + Vector3.right * 3);
                PossiblySpawnBanana(EndPos);
            }
        }
    }

    private void SpawnBanana(Vector3 pos)
    {
        GameObject go = Instantiate(bananaPrefab) as GameObject;
        pos.z += 0.1f;
        go.transform.position = pos;
    }

    private void SpawnPlatform(Vector3 pos)
    {
        GameObject go = Instantiate(platformPrefab) as GameObject;
		pos.z += 0.1f;
        go.transform.position = pos;
    }

    private void SpawnHalfpipe(Vector3 pos)
    {
        GameObject go = Instantiate(halfpipePrefab) as GameObject;
        pos.z += 0.1f;
        go.transform.position = pos;
    }

    private void SpawnRamp(Vector3 pos)
    {
        GameObject go = Instantiate(rampPrefab) as GameObject;
        pos.z += 0.1f;
        go.transform.position = pos;
    }

    private void PossiblySpawnBanana(Vector3 pos)
    {
        if (Random.RandomRange(0f, 1f) < 0.7f)
        {
            GameObject go = Instantiate(bananaPrefab) as GameObject;
            pos.z += 0.1f;
            go.transform.position = pos + Vector3.up * Random.RandomRange(2f, 4f);
        }
    }

}
