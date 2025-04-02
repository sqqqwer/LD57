using UnityEngine;

public class G : MonoBehaviour
{
    public static GameObject player;
    public static UI UI;
    [SerializeField] private GameObject _player;
    [SerializeField] private UI _UI;
    public static string colorRed = "C81414";


    private void Awake()
    {
        player = _player;
        UI = _UI;
    }
    private void Start()
    {
        MetaGame.Instance.StartGame();
    }
}
