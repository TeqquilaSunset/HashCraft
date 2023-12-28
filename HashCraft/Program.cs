using HashCraft;
using System.Text;
using System.CommandLine;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.CommandLine.Invocation;
using HashCraft.HashAlgorithms;
using System.Security.Cryptography;
using HashCraft.CryptoAlgorithm;


namespace HashCraft;

class Program
{
    public static async Task Main(string[] args)
    {
        // Флаг -p password
        var password = new Option<string>(
            aliases: new[] { "-p", "--password" },
            description: "The password that will be hashed")
        {
            IsRequired = true,
            Arity = ArgumentArity.ExactlyOne
        };

        // Флаг -s salt
        var salt = new Option<string>(
            aliases: new[] { "-s", "--salt" },
            description: "The salt that will be taken into account when hashing the password")
        {
            IsRequired = true,
            Arity = ArgumentArity.ExactlyOne
        };

        //Флаг -d
        var use3Des = new Option<bool>(
            aliases: new[] { "-d", "--des" },
            description: "3Des")
        {
            IsRequired = false,
            Arity = ArgumentArity.Zero
        };
        use3Des.SetDefaultValue(false);

        // Действие выполняемое после получения параметров
        Action<string, string, bool> hashHandler = (password, salt, use3Des) =>
        {
            //Инициализация хеш серивса и указание алгоритма хеширования 
            HashService hashService = new HashService(new Sha256HashAlgorithm(), new TripleDes());
            string hashedPassword = hashService.ComputeHashWithSalt(password, salt, use3Des);
            Console.WriteLine(hashedPassword);
        };

        var root = new RootCommand("A utility for creating a hash with salt");
        root.Add(password);
        root.Add(salt);
        root.Add(use3Des);
        root.SetHandler(hashHandler, password, salt, use3Des);
        //await root.InvokeAsync(args);
        await root.InvokeAsync("-p password -s salt -d");
    }
}