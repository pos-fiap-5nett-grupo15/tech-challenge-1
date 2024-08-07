using ContactsManagement.Infrastructure.Crypto;

var crypt = new CryptoService();
var encryptedValue = crypt.Encrypt("value_to_encrypt");

Console.WriteLine("ENCRYPTED VALUE:");
Console.WriteLine(encryptedValue);
Console.ReadLine();