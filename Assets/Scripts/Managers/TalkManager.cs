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
        talkData.Add(1000, new string[] { "반갑네, 난 파르타 마을의 기사 타르파스라고 하네.", "기사 모집 공고를 보고 기사로 지원했다지?", "분명 쉽지는 않은 길이 될걸세.", "그럼에도 꼭 상급 기사가 되겠다고?","당찬 포부가 맘에 드는군!","그럼 상급 기사가 되는 법을 알려주겠네.","마을 광장의 표지판을 보았는가?","마을의 우측에 파르타 마을의 관문이 있네.","표지판이 그 길을 알려줄거야.", "그 관문을 나서면 끊임없이 공격해오는 적들을 마주할걸세.","물론 직접 그들과 마주하는 것은 아니야.","전투 아바타를 조종하여 적과 전투하는 것이네.", "그들의 공격을 막아내어 평판을 올리면", "어느 순간 멋진 상급 기사가 될 수 있을걸세.","그럼 무운을 빌지!" });
        talkData.Add(100, new string[] { "직진 - 파르타 성", "우측 - 파르타 마을 관문","파르타 성의 석상에 상호작용 하면 개명 신청이 가능합니다." });
    }
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
