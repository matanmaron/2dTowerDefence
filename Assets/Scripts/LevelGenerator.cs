using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Texture2D Map;

    private GameManager _GameManager;

    void Start()
    {
        GenerateLevel();
        _GameManager = GameObject.FindGameObjectWithTag("GameManaager");
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < Map.width; x++)
        {
            for (int y = 0; y < Map.height; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = Map.GetPixel(x, y);
        if (pixelColor.a == 0)
        {
            if (_GameManager.DebugLevel >= 3) { Debug.Log($"transparent pixel found:({x},{y})"; }
            return; //pixel is transparent, move on !
        }
        if (_GameManager.DebugLevel >= 2){ Debug.Log($"pixel found: ({x},{y})={pixelColor}"); }
    }
}
