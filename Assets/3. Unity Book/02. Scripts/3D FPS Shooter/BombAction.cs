using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    public int attackPower = 10;
    public float explosionRadius = 5f;
    
    private void OnCollisionEnter(Collision collision) // 수류탄이 무엇인가 충돌할 경우
    {
        // 수류탄이 충돌한 위치에서 Radius만큼 9번 레이어 대상을 cols에 할당
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 9);

        for (int i = 0; i < cols.Length; i++)        
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
        

        GameObject eff = Instantiate(bombEffect); // 파티클 생성
        eff.transform.position = transform.position; // 파티클 위치 초기화
        
        Destroy(gameObject);
    }
}