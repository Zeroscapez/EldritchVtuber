using UnityEngine;
using UnityEngine.UI;

public class HyperLinkController : MonoBehaviour
{
    private Button buttonRef;
    public GameObject website1;
    

    public void Awake()
    {
        buttonRef = GetComponent<Button>();
        buttonRef.onClick.AddListener(OpenPanel);

    }
    public void OpenPanel()
    {
        website1.SetActive(true);
    }

    public void ClosePanel()
    {
     website1?.SetActive(false);
    }
}
