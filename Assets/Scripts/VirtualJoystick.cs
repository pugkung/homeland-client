using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    public Image ImgBg;
    public Image ImgJoystick;

    private Vector3 _inputVector;
    public Vector3 InputVector {
        get {
            return _inputVector;
        }
    }

    public void Start()
    {
        ImgJoystick.enabled = false;
    }


    public void OnPointerDown(PointerEventData e) {
        ImgJoystick.enabled = true;
        OnDrag(e);
    }

    public void OnDrag(PointerEventData e) {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(ImgBg.rectTransform,
                                                                    e.position,
                                                                    e.pressEventCamera,
                                                                    out pos)) {
            Debug.Log(pos);
            pos.x = ((pos.x - ImgBg.rectTransform.position.x) / ImgBg.rectTransform.sizeDelta.x);
            pos.y = ((pos.y + ImgBg.rectTransform.position.y) / ImgBg.rectTransform.sizeDelta.y);

            _inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 -1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            ImgJoystick.rectTransform.anchoredPosition = new Vector3(_inputVector.x * (ImgBg.rectTransform.sizeDelta.x * .4f),
                                                                     _inputVector.z * (ImgBg.rectTransform.sizeDelta.y * .4f));
        }
    }   

    public void OnPointerUp(PointerEventData e) {
        _inputVector = Vector3.zero;
        ImgJoystick.rectTransform.anchoredPosition = Vector3.zero;
        ImgJoystick.enabled = false;
    }


    public float getX() {
        if (_inputVector.x != 0) {
            return _inputVector.x;
        }

        return Input.GetAxis("Horizontal");
    }

    public float getY() {
        if (_inputVector.z != 0) {
            return _inputVector.z;
        }

        return Input.GetAxis("Vertical");
    }

}