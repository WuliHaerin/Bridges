using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SgLib;



public class Ad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public GameObject AdPanel;

    public void SetAdPanel(bool a)
    {
        AdPanel.SetActive(a);
    }

    // Update is called once per frame
    public void ClickBtn()
    {
        AdManager.ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {
                    CoinManager.Instance.AddCoins(200);
                    SetAdPanel(false);

                    AdManager.clickid = "";
                    AdManager.getClickid();
                    AdManager.apiSend("game_addiction", AdManager.clickid);
                    AdManager.apiSend("lt_roi", AdManager.clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("�ۿ�������Ƶ���ܻ�ȡ����Ŷ��");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("�������쳣�������¿���棡");
            });

    }


  private void Fail()
    {


        AdManager.ShowInterstitialAd("1lcaf5895d5l1293dc",
            () => {
                Debug.LogError("--����������--");

            },
            (it, str) => {
                Debug.LogError("Error->" + str);
            });
    }



}
