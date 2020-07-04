using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace adventure_game
{
    class Program

    {
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            string szoba = "nappali";
            bool nez_n = false;
            bool nez_f = false;
            Console.WriteLine("Szabadulás a szobából");
            Console.WriteLine("\nEgy hideg padlón fekszel, és borzasztó fejfájásod van.\n" +
                "Nem tudod, hogyan kerültél ide, az utolsó emléked, hogy a város utcáin sétáltál,\n" +
                "amikor hirtelen hátulról megragadtak és kloroformos kendővel elkábítottak.\n" +
                "Felállsz majd a sötétben tapogatozva egy régi, elhagyatott szobában találod magad.\n" +
                "(a következő parancsokat használhatod: menj, nézd, vedd fel, tedd le, nyisd, húzd, törd)");
            string parancs = " ";
            while (szoba == "nappali")
            {
                parancs = Console.ReadLine();
                Console.Clear();
                if (!nez_n)
                    if (parancs.ToLower() != "nézd") Console.WriteLine("Előbb nézd meg mik vannak a szobában!");
                    else
                    {
                        Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                            "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                            "Tőled nyugatra egy ajtót pillantasz meg.");
                        nez_n = true;
                    }
                else
                    if (parancs.ToLower() == "nézd") Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                        "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                        "Tőled nyugatra egy ajtót pillantasz meg.");
                if (parancs.ToLower() == "menj nyugat")
                {
                    Console.WriteLine("Elindulsz az ajtó irányába, majd kinyitod. Egy másik szobában találod magad.");
                    szoba = "fürdőszoba";
                }
            }
            while (szoba == "fürdőszoba")
            {
                parancs = Console.ReadLine();
                Console.Clear();
                if (!nez_f)
                    if (parancs.ToLower() != "nézd") Console.WriteLine("Előbb nézd meg mik vannak a szobában!");
                    else
                    {
                        Console.WriteLine("A fürdőszobában találod magad. Az egykor még kék csempék már barnán mutatnak. \n" +
                            "Egy kádon kívűl már semmi se található a szobában. Talán a kádban lehet valami...");
                        nez_f = true;

                    }
                else
                {

                }

            }

            Console.ReadKey();
        }
    }

}
