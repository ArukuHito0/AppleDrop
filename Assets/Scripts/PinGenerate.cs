using UnityEngine;

public class PinGenerate : MonoBehaviour
{
    [SerializeField] private GameObject pinObj;
    [SerializeField] private int pinRow;         // 縦何列あるか
    [SerializeField] private int pinCnt;         // 一列に何個並べるか
    [SerializeField] private float pinSpacing;   // ピンの間の距離

    [SerializeField] private Vector3 offset; // ピンを置き始める基準位置

    private void PinSpawn(Vector3 pos)
    {
        Instantiate(pinObj, pos, Quaternion.identity, this.gameObject.transform);
    }

    private void PinSetup()
    {
        for (int i = 0; i < pinRow; i++)
        {
            PinLineup(i);
        }
    }

    private void PinLineup(int rowCnt)
    {
        var cnt = rowCnt % 2 != 0 ? pinCnt - 1 : pinCnt;

        for (int i = 0; i < cnt / 2; i++)
        {
            PinSpawn(PinPosCalculate(i, rowCnt));
        }

        // 折り返してピンを設置

        cnt = rowCnt % 2 != 0 ? pinCnt : pinCnt - 2;

        for (int i = 1; i <= cnt / 2; i++)
        {
            PinSpawn(PinPosCalculate(-i, rowCnt));
        }
    }

    private Vector3 PinPosCalculate(int num, int rowCnt)
    {
        var pos = Vector3.zero;

        if (rowCnt % 2 == 0)
            pos.x = num * pinSpacing;
        else
            pos.x = num * pinSpacing + pinSpacing / 2;

        pos.y = -rowCnt * pinSpacing;

        return pos + offset;
    }

    private void Awake()
    {
        PinSetup();
    }
}
