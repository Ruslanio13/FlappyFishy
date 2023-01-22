using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    [SerializeField] private BirdEventHandler _eventHandler;

    private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnButtonClick()
    {
        _eventHandler.SwitchedToMenu?.Invoke();
    }
}
