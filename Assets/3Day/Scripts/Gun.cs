using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunState 
    {
        Ready, // 총알이 다 있는 경우
        Empty, // 비어있는 경우
        Reloading // 재장전이 필요한 경우
    }
    // get 다른 사용자가 값을 가져갈 수 있음
    // set 변수에 값을 할당할 수 있음
    public GunState gunState { get; private set; }

    public Transform gunFirePosition; // 총구의 위치를 관리하는 기능
    private LineRenderer bulletLine; // 총알의 선을 그리는 기능
    private AudioSource audioSource; // 소리를 관리하는 기능
    public AudioClip gunFireSound; // 총 소리 클립
    private Vector3 hitPoint; // 총알이 맞은 포인트

    // 총 연사 관련 정보
    private float lastFireTime; // 총을 마지막으로 발사한 시점
    public float fireDelayTime; // 총의 지연시간 (연사력)

    // 총 생태 정보
    public int damage = 10; // 총알의 데미지
    public float distance; // 총알의 최대 거리
    public float reloadTime; // 재장전이 걸리는 시간
    private int ammoToFill; // 남은 총알 계산
    public int ammoReMain; // 남은 전체 총알
    public int magazineSize; // 탄창 크기
    public int magazineAmmo; // 탄창에 남은 총알

    private void Start()
    {
        bulletLine = GetComponent<LineRenderer>(); // 현제 오브젝트에 LineRenderer Component 변수에 저장
        audioSource = GetComponent<AudioSource>(); // 현제 오브젝트에 AudioSource Component 변수에 저장
        gunState = GunState.Ready;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1")) // 마우스 좌 클릭
        {
            if (gunState == GunState.Ready && Time.time >= lastFireTime + fireDelayTime) // 총을 쏠 수 있고 현제 시간이 마지막으로 총을 쏜 시점 + 총 딜레이보다 클 때 true
            {
                RaycastHit hit; // 맞은 오브젝트를 저장할 변수

                // Physics.Raycast(시작 점, 방향 + 거리, 히트 정보를 반환 받을 변수)
                if (Physics.Raycast(gunFirePosition.position, gunFirePosition.forward * distance, out hit)) // 레이저를 쏨 레이저에 오브젝트가 맞으면 true
                {
                    Debug.Log(hit.collider.name);

                    Target hitTarget = hit.collider.GetComponent<Target>();

                    if (hitTarget)
                    {
                        hitTarget.Damage(damage);
                    }

                    if (hit.rigidbody)
                    {
                        hit.rigidbody.AddForce(-hit.normal * 100f);
                    }
                }
                //Debug.DrawRay(gunFirePosition.position, gunFirePosition.forward * distance, Color.red); 

                StartCoroutine(ShotEffect(hit.point));
                lastFireTime = Time.time; // 현제 시간을 저장
                magazineAmmo--;

                if (magazineAmmo <= 0)
                {
                    magazineAmmo = 0;
                    gunState = GunState.Empty;
                }
            }
        }

        // 재장전 코드
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (gunState == GunState.Reloading || ammoReMain <= 0 || magazineAmmo >= magazineSize)
            {
                return;
            }

            Debug.Log("재장전 중");
            StartCoroutine(ReloadingSystem());
        }
    }

    public IEnumerator ReloadingSystem()
    {
        gunState = GunState.Reloading;

        yield return new WaitForSeconds(reloadTime);

        ammoToFill = Mathf.Clamp(magazineSize - magazineAmmo, 0, ammoReMain);
        magazineAmmo += ammoToFill;
        ammoReMain -= ammoToFill;

        gunState = GunState.Ready;
        Debug.Log("재장전 완료");
    }

    public IEnumerator ShotEffect(Vector3 hitPosition)
    {
        bulletLine.enabled = true; // 활성화
        bulletLine.SetPosition(0, gunFirePosition.position); // 시작 위치
        bulletLine.SetPosition(1, hitPosition); // 오브젝트가 맞은 위치
        audioSource.PlayOneShot(gunFireSound); // 소리 실행
        yield return new WaitForSeconds(0.03f); // 0.03초 만큼 지연

        bulletLine.enabled = false; // 비활성화
    }
}
