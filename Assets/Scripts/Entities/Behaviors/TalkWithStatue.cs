using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkWithStatue : MonoBehaviour
{
    public GameObject player;
    public float actionDistance = 1f;
    [SerializeField] private Image nickNamePanel;
    [SerializeField] private Text nickName;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject inGameInfo;

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (player == null)
			{
				return;
			}
			float distance = Vector3.Distance(transform.position, player.transform.position);
			if (distance <= actionDistance)
			{
				inGameInfo.SetActive(false);
                nickNamePanel.gameObject.SetActive(true);
			}
		}
	}
    public void UpdateNickName()
    {
        string nickname = inputField.text;
        if (!string.IsNullOrEmpty(nickname))
        {
            nickName.text = nickname;
        }
        else
        {
            int rand = Random.Range(0, 5);
            string[] nicknames = { "개똥이", "돌쇠", "만식이", "웅복이", "용구" };
            nickName.text = nicknames[rand];
        }

        nickNamePanel.gameObject.SetActive(false);
        inGameInfo.gameObject.SetActive(true);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
