using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private RuntimeAnimatorController maleController;
    [SerializeField] private RuntimeAnimatorController femaleController;
    [SerializeField] private Image nickNameField;
    [SerializeField] private Image parentAtSelectGender;
    [SerializeField] private GameObject inGameInfo;
    [SerializeField] private InputField inputField;
    [SerializeField] private Text nickName;
    // 성별 선택, 닉네임 설정, 씬 옮기기
    public void SelectGenderMale()
    {
        Sprite sprite = Resources.Load<Sprite>("Images/Idle/Male_Idle1");
        if(sprite != null)
        {
            sr.sprite = sprite;
        }
        playerAnimator.runtimeAnimatorController = maleController;
        parentAtSelectGender.gameObject.SetActive(false);
        nickNameField.gameObject.SetActive(true);
    }
    public void SelectGenderFemale() 
    {
        Sprite sprite = Resources.Load<Sprite>("Images/Idle/Female_Idle1");
        if (sprite != null)
        {
            sr.sprite = sprite;
        }
        playerAnimator.runtimeAnimatorController = femaleController;

        parentAtSelectGender.gameObject.SetActive(false);
        nickNameField.gameObject.SetActive(true);
    }
    public void SetNickName()
    {
        string nickname = inputField.text;
        if(!string.IsNullOrEmpty(nickname))
        {
            nickName.text = nickname;
        }
        else
        {
            int rand = Random.Range(0, 5);
            string[] nicknames = { "개똥이", "돌쇠","만식이","웅복이","용구" };
            nickName.text = nicknames[rand];
        }
        nickNameField.gameObject.SetActive(false);
        inGameInfo.gameObject.SetActive(true);
    }
}
