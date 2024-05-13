using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ݰ���, �� �ĸ�Ÿ ������ ��� Ÿ���Ľ���� �ϳ�.", "��� ���� ���� ���� ���� �����ߴ���?", "�и� ������ ���� ���� �ɰɼ�.", "�׷����� �� ��� ��簡 �ǰڴٰ�?","���� ���ΰ� ���� ��±�!","�׷� ��� ��簡 �Ǵ� ���� �˷��ְڳ�.","���� ������ ǥ������ ���Ҵ°�?","������ ������ �ĸ�Ÿ ������ ������ �ֳ�.","ǥ������ �� ���� �˷��ٰž�.", "�� ������ ������ ���Ӿ��� �����ؿ��� ������ �����Ұɼ�.","���� ���� �׵�� �����ϴ� ���� �ƴϾ�.","���� �ƹ�Ÿ�� �����Ͽ� ���� �����ϴ� ���̳�.", "�׵��� ������ ���Ƴ��� ������ �ø���", "��� ���� ���� ��� ��簡 �� �� �����ɼ�.","�׷� ������ ����!" });
        talkData.Add(100, new string[] { "���� - �ĸ�Ÿ ��", "���� - �ĸ�Ÿ ���� ����","�ĸ�Ÿ ���� ���� ��ȣ�ۿ� �ϸ� ���� ��û�� �����մϴ�." });
    }
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
