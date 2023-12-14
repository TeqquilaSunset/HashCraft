using HashCraft;
using System.Text;
using System.CommandLine;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.CommandLine.Invocation;

namespace HashCraft;

class Program
{
    public static async Task Main(string[] args)
    {
        var commandHandler = new CommandHandler();
        await commandHandler.Handle(args);
    }
}