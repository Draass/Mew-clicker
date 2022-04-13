using UnityEngine;

public class MenusHandler : MonoBehaviour
{

    public GameObject optionsMenu;

    private void Start()
    {
        optionsMenu.SetActive(false);
    }

    public void BackToPlayMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void GoToOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

}
