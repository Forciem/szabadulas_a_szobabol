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
            // változók
            string szoba = "nappali";
            bool nez_n = false;
            bool nez_f = false;
            bool doboz = false;
            bool kulcs = false;
            bool ajto = false;
            Console.WriteLine("Szabadulás a szobából");
            Console.WriteLine("\nEgy hideg padlón fekszel, és borzasztó fejfájásod van.\n" +
                "Nem tudod, hogyan kerültél ide, az utolsó emléked, hogy a város utcáin sétáltál,\n" +
                "amikor hirtelen hátulról megragadtak és kloroformos kendővel elkábítottak.\n" +
                "Felállsz majd a sötétben tapogatozva megtalálsz egy villanykapcsolót.\n" +
                "felkapcsolod, és utána látod, hogy egy régi, elhagyatott szobában találod magad.\n" +
                "(a következő parancsokat használhatod: menj, nézd, vedd fel, tedd le, nyisd, húzd, törd)");
            string parancs = " ";

            //nappali

            while (szoba == "nappali")
            {
                parancs = Console.ReadLine();
                parancs = parancs.ToLower();
                Console.Clear();
                if (!nez_n)

                    //nézd parancs

                    if (parancs != "nézd") Console.WriteLine("Előbb nézd meg mik vannak a szobában!");
                    else
                    {
                        Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                            "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                            "Tőled nyugatra egy ajtót pillantasz meg.");
                        nez_n = true;
                    }
                else
                {
                    if (parancs == "nézd")

                        Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                "Tőled nyugatra egy ajtót pillantasz meg.");

                    //menj parancs

                    if (parancs == "menj nyugat")
                    {
                        Console.WriteLine("Elindulsz az ajtó irányába. Lenyomod a kilincset, de az ajtót kulcsra zárták...");
                        if (parancs == "nyisd ajtó kulcs" && (kulcs && !ajto) || (!kulcs && ajto))
                        {
                            Console.WriteLine("A kulccsal kinyitod az ajtót,\n" +
                              "és egy másik szobában találod magad.");
                            szoba = "fürdőszoba";
                            kulcs = false;
                            ajto = true;
                        }

                    }
                    if (parancs == "menj") Console.WriteLine("Melyik irányba akarsz menni?");
                    else
                        if (parancs.Contains("menj") && !parancs.Contains("nyugat"))
                        Console.WriteLine("Ebbe az irányba nem tudsz menni!");              //kiírja, hogy nem lehet kinyitni a másik if miatt

                    //nyisd parancs

                    if (parancs.Contains("nyisd"))
                    {
                        if (parancs.Contains("szekrény")) Console.WriteLine("Megpróbálod kinyitni a szekrényt. Kisebb erőfeszítés után a\n" +
                        "beragadt ajtó kiugrik a helyéről. Az egyik polcon egy fadobozt pillantasz meg.");
                        else if (parancs.Contains("doboz") && doboz)
                        {
                            Console.WriteLine("Kinyitod a fadobozt. Egy ékszeres doboz az,\n" +
                            "de nyaklánc helyett csak egy kicsi kulcsot találsz benne.\n" +
                            "vajon mit nyithat?\n" +
                            "Megtaláltad a kulcsot!");
                            doboz = false;
                            kulcs = true;

                        }
                        else Console.WriteLine("Ezt nem tudod kinyitni!");

                    }


                    //vedd fel parancs

                    if (parancs.Contains("vedd fel"))
                    {
                        if (parancs.Contains("doboz"))
                        {
                            Console.WriteLine("Felvetted a fadobozt.");
                            doboz = true;
                        }
                        else Console.WriteLine("Ezt nem tudod felvenni!");
                    }



                }
            }

            //fürdőszoba

            while (szoba == "fürdőszoba")
            {
                parancs = Console.ReadLine();
                parancs = parancs.ToLower();
                Console.Clear();
                if (!nez_f)
                    if (parancs != "nézd") Console.WriteLine("Előbb nézd meg mik vannak a szobában!");
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

// oop nélkül