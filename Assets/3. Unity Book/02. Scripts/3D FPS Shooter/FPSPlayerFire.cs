using System.Collections;
using TMPro;
using UnityEditor.Build;
using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    #region 멤버변수
    private enum WeaponMode { Normal, Sniper }
    private WeaponMode wMode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private Animator anim;
    private ParticleSystem ps;

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject weapon01_R;
    public GameObject weapon02_R;

    public GameObject crosshair01;
    public GameObject crosshair02;
    public GameObject crosshair02_Zoom;

    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;

    public float throwPower = 15f;
    public int weaponPower = 5;

    private bool ZoomMode = false;
    #endregion

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();

        wMode = WeaponMode.Normal;
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        LeftClick();
        RightClick();
        AlphaKeypad();
    }

    #region 마우스 좌클릭 -> 총 발사
    void LeftClick()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            if (anim.GetFloat("MoveMotion") == 0)
                anim.SetTrigger("Attack");

            StartCoroutine(ShootEffectOn(0.05f));

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Raycast를 Enemy가 맞은 경우
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // Raycast를 맞은 대상이 Enemy가 아닌 경우
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;

                    ps.Play();
                }
            }
        }
    }
    #endregion

    #region 마우스 우클릭 -> 수류탄, 저격
    void RightClick()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
        {
            switch (wMode)
            {
                #region 일반
                case WeaponMode.Normal: // 일반 모드일 때 마우스 오른쪽 -> 수류탄 투척
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f) * throwPower, ForceMode.Impulse);
                    break;
                #endregion

                #region 스나이퍼
                case WeaponMode.Sniper: // 저격 모드일 때 마우스 오른쪽 -> 확대/축소 조준경

                    ZoomMode = !ZoomMode;
                    float fov = ZoomMode ? 15f : 60f;
                    Camera.main.fieldOfView = fov;

                    crosshair02_Zoom.SetActive(ZoomMode);
                    crosshair02.SetActive(!ZoomMode);

                    break;
                    #endregion
            }
        }
    }
    #endregion


    void AlphaKeypad()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeaponMode(WeaponMode.Normal);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeaponMode(WeaponMode.Sniper);
        }
    }

    void SetWeaponMode(WeaponMode mode)
    {
        wMode = mode;
        ZoomMode = false; // 확대 모드는 전환 시 항상 초기화
        Camera.main.fieldOfView = 60f;

        bool isNormal = (mode == WeaponMode.Normal);

        wModeText.text = isNormal ? "Normal Mode" : "Sniper Mode";

        weapon01.SetActive(isNormal);
        weapon02.SetActive(!isNormal);
        weapon01_R.SetActive(isNormal);
        weapon02_R.SetActive(!isNormal);
        crosshair01.SetActive(isNormal);
        crosshair02.SetActive(!isNormal);
        crosshair02_Zoom.SetActive(!isNormal);
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length - 1);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);

        eff_Flash[num].SetActive(false);
    }
}