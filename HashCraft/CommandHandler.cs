using HashCraft.HashAlgorithms;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCraft
{
    internal class CommandHandler
    {

        public async Task Handle(string[] args)
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

            var hash = new Command("hash-craft", "Compute hash with salt");
            hash.Add(password);
            hash.Add(salt);
            hash.Add(use3Des);

            // Действие выполняемое после получения параметров
            Action<string, string, bool> hashHandler = (password, salt, use3Des) =>
            {
                //Инициализация хеш серивса и указание алгоритма хеширования 
                HashService hashService = new HashService(new Sha256HashAlgorithm());
                string hashedPassword = hashService.ComputeHashWithSalt(password, salt);
                Console.WriteLine(hashedPassword);
            };

            hash.SetHandler(hashHandler, password, salt, use3Des);

            var root = new RootCommand("A utility for creating a hash with salt");
            root.Add(hash);
            await root.InvokeAsync(args);
        }
    }
}
