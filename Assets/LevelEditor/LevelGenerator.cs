
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

    // Use this for initialization
    void Start () 
	{
		
		GenerateLevel();
        colorMappings[0] = Player;
        colorMappings[1] = Asteroid;
        colorMappings[2] = SpeedAsteroid;
        colorMappings[3] = Bumper;
        colorMappings[4] = SlowBumper;
        colorMappings[5] = NoTouchZone;
        colorMappings[6] = Wall;
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

        Debug.Log("TEST TEST");

		if (pixelColor.a == 0)
		{
			//The pixel is transparrent.  Let's ignor it!
			return;
		}


		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(x,y);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}
	
	
}
