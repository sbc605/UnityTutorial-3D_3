using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField password;

    public TextMeshProUGUI notify;

    void Start()
    {
        notify.text = "";
    }

    public void SaveUserData()
    {
        if (!CheckInput(id.text, password.text))        
            return;       

        if (!PlayerPrefs.HasKey(id.text)) // ���� ����� ������ �� ������ id�� �ִ��� Ȯ��
        {
            PlayerPrefs.SetString(id.text, password.text);
            notify.text = "���̵� ������ �Ϸ�Ǿ����ϴ�.";
        }

        else // �Է��� id�� �����Ѵٸ�        
            notify.text = "�̹� �����ϴ� ���̵��Դϴ�.";
        
    }

    public void CheckUserData()
    {
        string pass = PlayerPrefs.GetString(id.text); // ���̵�(Key)�� ����� �н�����(Value)�� �������� ���

        if (password.text == pass)
            SceneManager.LoadScene(1);

        else
            notify.text = "�Է��Ͻ� ���̵�� �н����尡 ��ġ���� �ʽ��ϴ�.";
    }

    private bool CheckInput(string id, string pwd) // �Է� ���� Ȯ��
    {
        if (id == "" | pwd == "")
        {
            notify.text = "���̵� �Ǵ� �н����带 �Է����ּ���.";

            return false; // ��ǲ�� ����
        }
        else
        {
            return true;
        }
    }    
}
