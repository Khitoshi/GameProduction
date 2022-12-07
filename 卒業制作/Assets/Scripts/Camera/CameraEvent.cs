using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�J�����̃C�x���g����
public class CameraEvent : MonoBehaviour
{
    [HideInInspector]public Vector3 positon_ { get; set; }
    //prefab�������J�������i�[
    [SerializeField]private Camera event_camera_;

    //���������J�������i�[
    private new Camera camera_;

    //�A�N�e�B�u���p�t���O
    public bool is_active_ { get; set; }

    //�J�����A�N�e�B�u������
    public float active_time_ { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        camera_ = Instantiate(event_camera_, Camera.main.transform);
        camera_.gameObject.SetActive(false);
        is_active_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active_time_ <= 0)
        {
            is_active_ = false;
            camera_.gameObject.SetActive(false);
        }

        active_time_ -= Time.deltaTime;

        if (!is_active_) return;
        camera_.gameObject.SetActive(true);
        camera_.transform.position = positon_;
    }

    public void SetEvent(Vector3 position,bool activeflag)
    {
        is_active_ = activeflag;
        positon_ = position;
        active_time_ = 5.0f;
    }


}
