using UnityEditor;
using UnityEngine;

class LevelGenerator : MonoBehaviour
{
    public Camera GameCamera;
    public GameObject platformPrefab;
	public GameObject bananaPrefab;
    private Vector3 StartPos;
    private Vector3 EndPos;

    public float size = 2F;  //GO size = size * 2

    void Start()
    {
		GameCamera = Camera.main;
        StartPos = GameCamera.transform.position;
        EndPos = StartPos;
        EndPos += new Vector3(0, -2, 0);
        EndPos.Scale(new Vector3(1, 1, 0));
        
        for (int i = 0; i < 4; i++)
        {   
            SpawnPlatform(EndPos);
            EndPos += new Vector3(size*2, 0, 0);
        }
    }

    void Update()
    {
        if(GameCamera.transform.position.x + 20 > EndPos.x)
        {
            int r = Random.Range(0, 2);
			int i = 0;
            if (r == i++)
            {
                SpawnPlatform(EndPos);
                EndPos += new Vector3(size * 2, 0, 0);
			}
            else if (r == i++)
            {
                SpawnPlatform(EndPos);
                EndPos += new Vector3(size * 3, 0, 0);
            }
            else if (r == i++)
            {
                SpawnPlatform(EndPos);
                EndPos += new Vector3(size * 4, 0, 0);
            }
        }
    }

    private void SpawnPlatform(Vector3 pos)
    {
        GameObject go = Instantiate(platformPrefab) as GameObject;
        go.transform.position = pos;
    }

    private void GenerateDoubleScretch()
    {
    }

    private void GenerateJump()
    {
    }
}
