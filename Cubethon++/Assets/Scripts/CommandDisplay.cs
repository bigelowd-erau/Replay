using UnityEngine;
using UnityEngine.UI;

public class CommandDisplay : MonoBehaviour
{
    public Text prefab;

    public void AddCommandToDisplay(Command command)
    {
        Text newCommandDisp = Instantiate(prefab, transform);
        newCommandDisp.transform.SetAsFirstSibling();
        newCommandDisp.text = command.ToString();
    }
}
