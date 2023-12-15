using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerandaRoomController : MonoBehaviour
{

    public GameObject hangingbaskets;
    public GameObject petbedcushions;
    public GameObject petbed;
    public GameObject ceilingfan;
    public GameObject sidetablerightprops;
    public GameObject sidetableright;
    public GameObject pouf;
    public GameObject coffeetableprops;
    public GameObject coffeetable;
    public GameObject armchair;
    public GameObject armchairuppercushions;
    public GameObject armchairpillows;
    public GameObject lamp;
    public GameObject sofauppercushions;
    public GameObject sofapillows;
    public GameObject sofa;
    public GameObject sidetableleftprops;
    public GameObject sidetableleft;
    public GameObject planttree;
    public GameObject fence;
    public GameObject fenceprops;
    public GameObject curtains;
    public GameObject roof;
    public GameObject window;
    public GameObject trellis;
    public GameObject floormat;
    public GameObject floor;
    public GameObject wall;
    public GameObject background;


    public Button replayButton;

    private Queue<GameObject> objectQueue = new Queue<GameObject>(); // Hàng đợi chứa các đối tượng cần hiển thị theo thứ tự

    private void Awake()
    {
        InitializeQueue();
    }

    void AddGameObject()
    {
        objectQueue.Enqueue(background);
        objectQueue.Enqueue(floor);
        objectQueue.Enqueue(wall);
        objectQueue.Enqueue(roof);
        objectQueue.Enqueue(floormat);
        objectQueue.Enqueue(window);
        objectQueue.Enqueue(trellis);
        objectQueue.Enqueue(fence);
        objectQueue.Enqueue(curtains);
        objectQueue.Enqueue(fenceprops);
        objectQueue.Enqueue(planttree);
        objectQueue.Enqueue(sidetableleftprops);
        objectQueue.Enqueue(sidetableleft);
        objectQueue.Enqueue(sofa);
        objectQueue.Enqueue(sofapillows);
        objectQueue.Enqueue(sofauppercushions);
        objectQueue.Enqueue(lamp);
        objectQueue.Enqueue(armchair);
        objectQueue.Enqueue(armchairpillows);
        objectQueue.Enqueue(armchairuppercushions);
        objectQueue.Enqueue(coffeetable);
        objectQueue.Enqueue(coffeetableprops);
        objectQueue.Enqueue(pouf);
        objectQueue.Enqueue(sidetableright);
        objectQueue.Enqueue(sidetablerightprops);
        objectQueue.Enqueue(ceilingfan);
        objectQueue.Enqueue(petbed);
        objectQueue.Enqueue(petbedcushions);
        objectQueue.Enqueue(hangingbaskets);
    }


    void InitializeQueue()
    {
        // Thêm các đối tượng vào hàng đợi theo thứ tự
        AddGameObject();
        // Thêm các GameObjects khác vào hàng đợi...

        // Khởi tạo tất cả các đối tượng ở trạng thái tắt
        SetAllObjectsActiveState(true);
    }

    void SetAllObjectsActiveState(bool state)
    {
        foreach (GameObject obj in objectQueue)
        {
            obj.SetActive(state);
        }
    }

    public void OnReplay()
    {
        StartCoroutine(ShowObjectsWithDelay());
        // Gọi phương thức xuất hiện các đối tượng theo thứ tự với độ trễ
    }

    IEnumerator ShowObjectsWithDelay()
    {
        SetAllObjectsActiveState(false);
        yield return new WaitForSeconds(1f);

        while (objectQueue.Count > 0)
        {
            // Lấy đối tượng đầu hàng đợi
            GameObject currentObj = objectQueue.Dequeue();

            // Hiển thị đối tượng
            currentObj.SetActive(true);

            // Chờ một khoảng thời gian trước khi hiển thị đối tượng tiếp theo
            yield return new WaitForSeconds(0.5f); // Đổi giá trị độ trễ tại đây
        }

        AddGameObject();


        if (replayButton != null)
        {
            replayButton.interactable = true; // Cho phép button được ấn lại
        }



    }
}