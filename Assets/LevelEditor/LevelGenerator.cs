
using UnityEngine;

public class LevelGenerator : MonoBehaviour 
{

	public Texture2D map;
    public GameObject clickWall;
    public GameObject bgWall;
	public ColorToPrefab Player;
    public ColorToPrefab Asteroid;
    public ColorToPrefab SpeedAsteroid;
    public ColorToPrefab Bumper;
    public ColorToPrefab SlowBumper;
    public ColorToPrefab NoTouchZone;
    public ColorToPrefab Wall;
    public ColorToPrefab Portal;
    public ColorToPrefab ExitHole;
    private ColorToPrefab[] colorMappings;
    private Quaternion[] rotations;

    // Use this for initialization
    void Start () 
	{
        colorMappings = new ColorToPrefab[7];
        rotations = new Quaternion[7];
        for (int i = 0; i < 7; i++)
            rotations[i] = Quaternion.identity;
        colorMappings[0] = Player;
        colorMappings[1] = Asteroid;
        colorMappings[2] = SpeedAsteroid;
        colorMappings[3] = Bumper;
        colorMappings[4] = SlowBumper;
        colorMappings[5] = NoTouchZone;
        rotations[5] = Quaternion.Euler(-90, 0, 0);
        colorMappings[6] = Wall;
        Debug.Log(colorMappings[6].color);
        GenerateLevel();
    }

	void GenerateLevel ()
	{
        Instantiate(clickWall, new Vector3(100, 100, 0), Quaternion.Euler(0,-90,90), null);
        Instantiate(bgWall, new Vector3(100, 100, 20), Quaternion.Euler(0, -90, 90), null);
        for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x,y);
			}
		}

	}

	void GenerateTile (int x, int y)
	{
		Color pixelColor = map.GetPixel(x,y);

		if (pixelColor.a == 0)
		{
			return;
		}


		for (int i=0;i<7;i++)
		{
            if (colorMappings[i].color.Equals(pixelColor))
			{
                Debug.Log("equal color");
                Vector2 position = new Vector2(x,y);
				Instantiate(colorMappings[i].prefab, position, rotations[i], transform);
			}
		}
	}
	
	
}
