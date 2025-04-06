using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Playables;

public class G : MonoBehaviour
{
    public static GameObject player;
    public static GameObject cameraPlayer;
    public static UI UI;
    public static DrawingController drawingController;
    public static RiteAnimation rite;
    public static Music music;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _cameraPlayer;
    [SerializeField] private UI _UI;
    [SerializeField] private DrawingController _drawingController;
    [SerializeField] private RiteAnimation _rite;
    [SerializeField] private Music _music;
    public static string colorRed = "C81414";
    private static bool _isPause = true;
    public static bool isPause
    {
        get => _isPause;
        set
        {
            if (_isPause != value)
            {
                if (value == false)
                {
                    cameraPlayer.GetComponent<CinemachineInputAxisController>().enabled = true;
                }
                else
                {
                    cameraPlayer.GetComponent<CinemachineInputAxisController>().enabled = false;
                }
                _isPause = value;
            }
        }
    }

    private void Awake()
    {
        player = _player;
        cameraPlayer = _cameraPlayer;
        UI = _UI;
        drawingController = _drawingController;
        rite = _rite;
        music = _music;
    }
    private void Start()
    {
        MetaGame.Instance.StartGame();
    }
}
