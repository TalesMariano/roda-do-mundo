using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;

public class OpenWindow : MonoBehaviour, IPointerDownHandler, ISubmitHandler {

	public string link;

    public  void OnPointerDown(PointerEventData data)
    {
        OpenLinkJSPlugin(link);
    }

	public  void OnSubmit(BaseEventData data)
    {
        OpenLinkJSPlugin(link);
    }

	public void OpenLinkJSPlugin(string _link) {
		#if !UNITY_EDITOR
		openWindow(_link);
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}
