using HashCraft.HashAlgorithms;
using System;
using System.Collections.Generic;
using System.CommandLine;
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
                description: "Password")
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne
            };
            // Флаг -s salt
            var salt = new Option<string>(
                aliases: new[] { "-s", "--salt" },
                description: "Salt")
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne
            };

            var use3Des = new Option<bool>(
                aliases: new[] { "-d", "--des" },
                description: "3Des")
            {
                IsRequired = false,
                Arity = ArgumentArity.Zero
            };
            use3Des.SetDefaultValue(false);

            var hash = new Command("hash", "Compute hash with salt");
            hash.Add(password);
            hash.Add(salt);
            hash.Add(use3Des);

            Action<string, string, bool> hashHandler = (password, salt, use3Des) =>
            {
                HashService hashService = new HashService(new Sha256HashAlgorithm());
                string hashedPassword = hashService.ComputeHashWithSalt(password, salt);
                Console.WriteLine(hashedPassword);
            };

            hash.SetHandler(hashHandler, password, salt, use3Des);

            var root = new RootCommand("CLI app example");
            root.Add(hash);
            await root.InvokeAsync(args);
        }
    }
}
