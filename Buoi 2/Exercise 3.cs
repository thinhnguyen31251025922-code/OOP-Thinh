using System;

public class UserAccount
{
    // 1. Private backing fields (where needed)
    private string _password;
    private decimal _balance;

    // TODO 1: AccountId (Init-Only)
    public string AccountID { get; init; }
    // TODO 2: Username (Auto-Implemented)
    public string Username { get; set; }
    // TODO 3: Password (Write-Only)
    public string Password { set => _password = $"[ENCRYPTED]_{value}"; }
    // TODO 4: Balance (Full Property with Validation)
    public decimal Balance
    {
        get => _balance; 
        set
        {
            if (value >= 0) { _balance = value; }
            else
            {
                Console.WriteLine("Error: Balance cannot be negative!");
            }
        }
    }
    // TODO 5: IsVIP (Computed Read-Only)
    public bool IsVIP { get=>Balance >= 10000m; }
    // TODO 6: CreatedDate (Get-Only)
    public DateTime CreatedDate { get; }
    // Constructor
    public UserAccount()
    {
        // TODO: Initialize CreatedDate here
        CreatedDate = DateTime.Now;
    }
}
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}
class Program
{
    static void Main3(string[] args)
    {
        // --- TEST HARNESS ---

        // 1. Test Object Initialization & Init-Only Property
        UserAccount user = new UserAccount
        {
            AccountId = "ACC-99201",
            Username = "Alice_Code",
            Password = "SuperSecretPassword123"
        };

        // Attempting to modify AccountId after creation should fail compilation!
        user.AccountId = "ACC-00000"; // UNCOMMENT TO VERIFY COMPILER ERROR

        Console.WriteLine($"Account ID: {user.AccountId}");
        Console.WriteLine($"Username: {user.Username}");
        Console.WriteLine($"Account Created: {user.CreatedDate}");

        // 2. Test Write-Only Property
        // Attempting to read Password should fail compilation!
        // Console.WriteLine(user.Password); // UNCOMMENT TO VERIFY COMPILER ERROR

        // 3. Test Full Property Validation
        Console.WriteLine("\n--- Testing Balance Updates ---");
        user.Balance = 5000m;
        Console.WriteLine($"Current Balance: {user.Balance:C}");

        user.Balance = -200m; // Should display warning and ignore update
        Console.WriteLine($"Current Balance after invalid attempt: {user.Balance:C}");

        // 4. Test Computed Read-Only Property (IsVIP)
        Console.WriteLine($"\nIs VIP? {user.IsVIP}"); // Should be false ($5000 < $10000)

        user.Balance = 15000m;
        Console.WriteLine($"Updated Balance: {user.Balance:C}");
        Console.WriteLine($"Is VIP now? {user.IsVIP}"); // Should be true ($15000 >= $10000)
    }
}
