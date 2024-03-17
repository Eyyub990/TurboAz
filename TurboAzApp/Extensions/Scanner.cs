using TurboAzApp.Models.Stables;

namespace TurboAzApp.Extensions
{
    public static partial class Extension
    {
        public static T? Read<T>(string caption, string? message = null)
            where T : struct
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "please give a valid number";
            }

        l1:
            Print(caption);
            try
            {
                return (T)(Convert.ChangeType(Console.ReadLine(), typeof(T)) ?? default)!;
            }
            catch (Exception)
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }

        }
        public static string ReadString(string caption, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "please give a text";
            }

            Print(caption);
        l1:
            string value = Console.ReadLine()!;

            if (string.IsNullOrEmpty(message))
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }

            return value!;
        }
        public static T ChooseOption<T>(string caption, string? message = null)
            where T : Enum
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "An option must be chosen";
            }

            Type type = typeof(T);
            var backupColor = Console.ForegroundColor;



            Console.WriteLine("==========CHOOSE OPTION==========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Enum.GetValues(type))
            {
                Console.WriteLine($"{Convert.ChangeType(item, Enum.GetUnderlyingType(type))}. {item}");
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("=================================");


        l1:
            Print(caption);
            if (!(Enum.TryParse(type, Console.ReadLine(), ignoreCase: true, out object? value)) || !(Enum.IsDefined(type, value!)))
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }

            return (T)value;
        }

    }
}
