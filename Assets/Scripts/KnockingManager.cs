using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockingManager : MonoBehaviour
{
    public GameObject door; // Referencja do drzwi
    public float knockInterval = 0.5f; // Sta�a warto�� odst�pu czasu mi�dzy zapukaniami (0.5 sekundy)
    public int maxKnocks = 4; // Maksymalna ilo�� zapuka� przed otwarciem drzwi
    public AudioClip knockSound; // D�wi�k pukania do drzwi

    private int currentKnocks = 0; // Aktualna liczba zapuka�

    void Start()
    {
        // Tutaj mo�emy uruchomi� funkcj�, kt�ra losuje i obs�uguje zapukania
        StartCoroutine("KnockRandomly");
    }

    IEnumerator KnockRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(knockInterval); // Czekamy sta�� warto�� czasu przed ka�dym zapukaniem
            KnockOnDoor(); // Wywo�ujemy funkcj� obs�uguj�c� zapukanie
        }
    }

    void KnockOnDoor()
    {
        currentKnocks++; // Inkrementujemy liczb� zapuka�
        Debug.Log("Knock! Knock!"); // Wy�wietlamy komunikat w konsoli

        // Odtwarzamy d�wi�k pukania do drzwi
        if (knockSound != null)
        {
            AudioSource.PlayClipAtPoint(knockSound, transform.position);
        }

        if (currentKnocks >= maxKnocks || Random.value > 0.5f) // Sprawdzamy, czy osi�gn�li�my maksymaln� liczb� zapuka� lub losujemy, czy drzwi maj� si� otworzy�
        {
            OpenDoor(); // Otwieramy drzwi
        }
    }

    void OpenDoor()
    {
        // Zmieniamy po�o�enie drzwi o 90 stopni w osi Y
        door.transform.Rotate(new Vector3(0f, 90f, 0f));
        Debug.Log("Drzwi otwarte!"); // Wy�wietlamy komunikat w konsoli
        currentKnocks = 0; // Resetujemy liczb� zapuka�
    }
}