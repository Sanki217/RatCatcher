using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockingManager : MonoBehaviour
{
    public GameObject door; // Referencja do drzwi
    public float knockInterval = 0.5f; // Sta³a wartoœæ odstêpu czasu miêdzy zapukaniami (0.5 sekundy)
    public int maxKnocks = 4; // Maksymalna iloœæ zapukañ przed otwarciem drzwi
    public AudioClip knockSound; // DŸwiêk pukania do drzwi

    private int currentKnocks = 0; // Aktualna liczba zapukañ

    void Start()
    {
        // Tutaj mo¿emy uruchomiæ funkcjê, która losuje i obs³uguje zapukania
        StartCoroutine("KnockRandomly");
    }

    IEnumerator KnockRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(knockInterval); // Czekamy sta³¹ wartoœæ czasu przed ka¿dym zapukaniem
            KnockOnDoor(); // Wywo³ujemy funkcjê obs³uguj¹c¹ zapukanie
        }
    }

    void KnockOnDoor()
    {
        currentKnocks++; // Inkrementujemy liczbê zapukañ
        Debug.Log("Knock! Knock!"); // Wyœwietlamy komunikat w konsoli

        // Odtwarzamy dŸwiêk pukania do drzwi
        if (knockSound != null)
        {
            AudioSource.PlayClipAtPoint(knockSound, transform.position);
        }

        if (currentKnocks >= maxKnocks || Random.value > 0.5f) // Sprawdzamy, czy osi¹gnêliœmy maksymaln¹ liczbê zapukañ lub losujemy, czy drzwi maj¹ siê otworzyæ
        {
            OpenDoor(); // Otwieramy drzwi
        }
    }

    void OpenDoor()
    {
        // Zmieniamy po³o¿enie drzwi o 90 stopni w osi Y
        door.transform.Rotate(new Vector3(0f, 90f, 0f));
        Debug.Log("Drzwi otwarte!"); // Wyœwietlamy komunikat w konsoli
        currentKnocks = 0; // Resetujemy liczbê zapukañ
    }
}