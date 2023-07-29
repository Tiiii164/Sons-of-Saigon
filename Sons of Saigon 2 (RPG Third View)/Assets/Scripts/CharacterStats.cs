using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterStats : MonoBehaviour
{
    [SerializeField] int BaseStamina_PerLevel = 5;
    [SerializeField] int BaseStamina_Offset = 10;
    [SerializeField] int StaminaConverseToHealth = 10;
    [SerializeField] float StaminaConverseToDamage = 1.25f;
    [SerializeField] TextMeshProUGUI StaminaText;
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] TextMeshProUGUI DamageText;


    // Định nghĩa một biến static để lưu thể hiện Singleton
    private static CharacterStats instance;

    // Khai báo các thông số và hành vi của nhân vật ở đây

    // Phương thức public để truy cập thông qua Singleton
    public static CharacterStats Instance
    {
        get
        {
            // Nếu instance chưa được khởi tạo, hãy tìm hoặc tạo mới một đối tượng có script CharacterStats trong Scene
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterStats>();
            }

            return instance;
        }
    }



    public int BaseStamina { get; set; } = 0;

    public int Stamina
    {
        get
        {
            return BaseStamina;
        }
    }
    public int MaxHealth
    {
        get
        {
            return Stamina * StaminaConverseToHealth;
        }
    }
    public int Damage
    {
        get
        {
            return (int)(Stamina * StaminaConverseToDamage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUpdateLevel(int previousLevel,int currentLevel)
    {
        BaseStamina = currentLevel * BaseStamina_PerLevel + BaseStamina_Offset;
        StaminaText.text = $"Stamina: {Stamina}";
        HealthText.text = $"Max Health: {MaxHealth}";
        DamageText.text = $"Damage: {Damage}";
    }
}
