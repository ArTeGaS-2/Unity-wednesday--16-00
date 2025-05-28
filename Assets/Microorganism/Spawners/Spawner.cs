using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Список з gameObject(ігрові об'єкти) для спавну
    public List<GameObject> organisms;

    // Загальне число мікроорганізмів, що будуть створені на сцені
    public int spawnNumber = 10;
    
    // Діаметр, в якому будуть спавнитись об'єкти
    public float diameter = 5f;

    // Координати в яких викликається об'єкт
    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        // Виконує блок коду до тих пір, поки змінна "i"
        // меньше за змінну "SpawnNumber"
        // "i" збільшується на 1 кожну ітерацію циклу
        for (int i = 0; i < spawnNumber; i++)
        {
            // Визначаємо випадкові координати по "x" та "z" в діапазоні
            x_Pos = Random.Range(-diameter, diameter);
            z_Pos = Random.Range(-diameter, diameter);

            // Обираємо випадковий мікроорганізм, з обраних
            GameObject objectToSpawn = organisms[
                Random.Range(0, organisms.Count)];

            // Визначаємо точку розміщення на ігровому полі
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);
            
            // Створюємо обраний об'єкт, в обраному місці, без зміни обертання
            Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
        }
    }
}
