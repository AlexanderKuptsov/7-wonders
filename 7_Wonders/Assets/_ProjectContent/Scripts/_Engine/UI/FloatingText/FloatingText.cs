using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

    public Animator animator;

    private Text text;

	void Awake ()
    {
        var clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length >= 1) Destroy(gameObject, clipInfo[0].clip.length - 0.1f);

        text = animator.GetComponent<Text>();
	}
	
    public void SetText(string _text)
    {
        animator.GetComponent<Text>().text = _text;
    }

    public void SetColor(Color _color)
    {
        text.color = _color;
    }

    public void ChangeTextScale(float _scaleModifier)
    {
        text.fontSize = (int)(text.fontSize * _scaleModifier);
    }
}
