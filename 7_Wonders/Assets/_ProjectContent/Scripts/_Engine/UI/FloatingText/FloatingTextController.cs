using UnityEngine;

public class FloatingTextController : Singleton<FloatingTextController> {

    private static FloatingText popupText;
    private static GameObject canvas;

    private const float RANDOM_RANGE_BORDER = 0.75f;

    public override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        if (!popupText)
            popupText = Resources.Load<FloatingText>("Prefabs/Help/PopupTextParent");        
    }

    public static void CreateFloatingText(string _text, Vector3 _location)
    {
        FloatingTextCreation(_text, _location);
    }

    public static void CreateFloatingText(string _text, Vector3 _location, Color _color)
    {
        var fText = FloatingTextCreation(_text, _location);
        fText.SetColor(_color);
    }

    public static void CreateFloatingText(string _text, Vector3 _location, float _scaleModifier)
    {
        var fText = FloatingTextCreation(_text, _location);
        fText.ChangeTextScale(_scaleModifier);
    }

    public static void CreateFloatingText(string _text, Vector3 _location, Color _color, float _scaleModifier)
    {
        var fText = FloatingTextCreation(_text, _location);
        fText.SetColor(_color);
        fText.ChangeTextScale(_scaleModifier);
    }

    private static FloatingText FloatingTextCreation(string _text, Vector3 _location)
    {
        var instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(_location);
        screenPosition.x += Random.Range(-RANDOM_RANGE_BORDER, RANDOM_RANGE_BORDER);
        screenPosition.y += Random.Range(-RANDOM_RANGE_BORDER, RANDOM_RANGE_BORDER);

        Transform fTextTransform;
        (fTextTransform = instance.transform).SetParent(canvas.transform, false);
        fTextTransform.position = screenPosition;
        fTextTransform.rotation = canvas.transform.rotation;
        instance.SetText(_text);
        return instance;
    }    
}
