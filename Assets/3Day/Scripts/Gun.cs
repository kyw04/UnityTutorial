using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunState 
    {
        Ready, // �Ѿ��� �� �ִ� ���
        Empty, // ����ִ� ���
        Reloading // �������� �ʿ��� ���
    }
    // get �ٸ� ����ڰ� ���� ������ �� ����
    // set ������ ���� �Ҵ��� �� ����
    public GunState gunState { get; private set; }

    public Transform gunFirePosition; // �ѱ��� ��ġ�� �����ϴ� ���
    private LineRenderer bulletLine; // �Ѿ��� ���� �׸��� ���
    private AudioSource audioSource; // �Ҹ��� �����ϴ� ���
    public AudioClip gunFireSound; // �� �Ҹ� Ŭ��
    private Vector3 hitPoint; // �Ѿ��� ���� ����Ʈ

    // �� ���� ���� ����
    private float lastFireTime; // ���� ���������� �߻��� ����
    public float fireDelayTime; // ���� �����ð� (�����)

    // �� ���� ����
    public int damage = 10; // �Ѿ��� ������
    public float distance; // �Ѿ��� �ִ� �Ÿ�
    public float reloadTime; // �������� �ɸ��� �ð�
    private int ammoToFill; // ���� �Ѿ� ���
    public int ammoReMain; // ���� ��ü �Ѿ�
    public int magazineSize; // źâ ũ��
    public int magazineAmmo; // źâ�� ���� �Ѿ�

    private void Start()
    {
        bulletLine = GetComponent<LineRenderer>(); // ���� ������Ʈ�� LineRenderer Component ������ ����
        audioSource = GetComponent<AudioSource>(); // ���� ������Ʈ�� AudioSource Component ������ ����
        gunState = GunState.Ready;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1")) // ���콺 �� Ŭ��
        {
            if (gunState == GunState.Ready && Time.time >= lastFireTime + fireDelayTime) // ���� �� �� �ְ� ���� �ð��� ���������� ���� �� ���� + �� �����̺��� Ŭ �� true
            {
                RaycastHit hit; // ���� ������Ʈ�� ������ ����

                // Physics.Raycast(���� ��, ���� + �Ÿ�, ��Ʈ ������ ��ȯ ���� ����)
                if (Physics.Raycast(gunFirePosition.position, gunFirePosition.forward * distance, out hit)) // �������� �� �������� ������Ʈ�� ������ true
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
                lastFireTime = Time.time; // ���� �ð��� ����
                magazineAmmo--;

                if (magazineAmmo <= 0)
                {
                    magazineAmmo = 0;
                    gunState = GunState.Empty;
                }
            }
        }

        // ������ �ڵ�
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (gunState == GunState.Reloading || ammoReMain <= 0 || magazineAmmo >= magazineSize)
            {
                return;
            }

            Debug.Log("������ ��");
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
        Debug.Log("������ �Ϸ�");
    }

    public IEnumerator ShotEffect(Vector3 hitPosition)
    {
        bulletLine.enabled = true; // Ȱ��ȭ
        bulletLine.SetPosition(0, gunFirePosition.position); // ���� ��ġ
        bulletLine.SetPosition(1, hitPosition); // ������Ʈ�� ���� ��ġ
        audioSource.PlayOneShot(gunFireSound); // �Ҹ� ����
        yield return new WaitForSeconds(0.03f); // 0.03�� ��ŭ ����

        bulletLine.enabled = false; // ��Ȱ��ȭ
    }
}
