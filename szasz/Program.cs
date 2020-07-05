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

            static void Start()
            {
                // változók
                string szoba = "nappali";
                bool nez_n = false;
                bool nez_f = false;
                bool doboz = false;
                bool kulcs = false;
                bool ajto = false;
                bool parancs_fut = false;
                bool feszitovas = false;
                bool ablak = false;
                Console.WriteLine("Szabadulás a szobából");
                Console.WriteLine("\nEgy hideg padlón fekszel, és borzasztó fejfájásod van.\n" +
                    "Nem tudod, hogyan kerültél ide, az utolsó emléked, hogy a város utcáin sétáltál,\n" +
                    "amikor hirtelen hátulról megragadtak és kloroformos kendővel elkábítottak.\n" +
                    "Felállsz majd a sötétben tapogatozva megtalálsz egy villanykapcsolót.\n" +
                    "felkapcsolod, és utána látod, hogy egy régi, elhagyatott szobában találod magad.\n" +
                    "(a következő parancsokat használhatod: menj, nézd, vedd fel, tedd le, nyisd, húzd, törd)");
                string parancs = " ";

                //nappali

                while (szoba != "gyoztes")
                {
                    while (szoba == "nappali")
                    {
                        parancs_fut = false;
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
                            if (parancs == "nézd" && ablak) Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                    "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                    "Tőled nyugatra egy ajtót pillantasz meg.\n" +
                                    "Északra egy betört ablak van.");

                            //menj parancs

                            if (parancs == "menj nyugat")
                            {
                                Console.WriteLine("Elindulsz az ajtó irányába. Lenyomod a kilincset, de az ajtót kulcsra zárták...");
                                parancs_fut = true;


                            }
                            if (parancs == "menj észak" && ablak)
                            {
                                Console.WriteLine("Megközelíted az ablakot. Óvatosan átmászol a\n" +
                                    "a kitört résen.");
                                parancs_fut = true;
                                szoba = "gyoztes";
                            }
                            if (parancs == "menj")
                            {
                                Console.WriteLine("Melyik irányba akarsz menni?");
                                parancs_fut = true;
                            }
                            if (parancs.Contains("menj") && !parancs.Contains("nyugat") || parancs.Contains("észak") && ablak)
                            {
                                Console.WriteLine("Ebbe az irányba nem tudsz menni!");
                                parancs_fut = true;
                            }
                            {

                            }

                            //nyisd parancs

                            if (parancs.Contains("nyisd"))
                            {
                                if (parancs == "nyisd szekrény")
                                {
                                    Console.WriteLine("Megpróbálod kinyitni a szekrényt. Kisebb erőfeszítés után a\n" +
                                    "beragadt ajtó kiugrik a helyéről. Az egyik polcon egy fadobozt pillantasz meg.");
                                    parancs_fut = true;
                                }
                                if (parancs == "nyisd ajtó kulcs" && (kulcs && !ajto) || (!kulcs && ajto))
                                {
                                    Console.WriteLine("A kulccsal kinyitod az ajtót,\n" +
                                      "és egy másik szobában találod magad.");
                                    szoba = "fürdőszoba";
                                    kulcs = false;
                                    ajto = true;
                                    parancs_fut = true;
                                }
                                if (parancs == "nyisd doboz" && doboz)
                                {

                                    Console.WriteLine("Kinyitod a fadobozt. Egy ékszeres doboz az,\n" +
                                    "de nyaklánc helyett csak egy kicsi kulcsot találsz benne.\n" +
                                    "vajon mit nyithat?\n" +
                                    "Megtaláltad a kulcsot!");
                                    doboz = false;
                                    kulcs = true;
                                    parancs_fut = true;
                                }

                                if (parancs == "nyisd ablak") Console.WriteLine("Megpróbálod kinyitni az ablakot, de beragadt.\n" +
                                     "Hacsak valamivel be tudnád törni...");
                            }


                            //vedd fel parancs

                            if (parancs.Contains("vedd fel"))
                            {
                                if (parancs == "vedd fel doboz")
                                {
                                    Console.WriteLine("Felvetted a fadobozt!");
                                    doboz = true;
                                    parancs_fut = true;
                                }
                                else Console.WriteLine("Ezt nem tudod felvenni!");
                                parancs_fut = true;
                            }

                            //húzd parancs

                            if (parancs.Contains("húzd"))
                            {
                                if (parancs == "húzd szekrény")
                                {
                                    Console.WriteLine("Elhúzod a szekrényt. Mögötte egy ablak található! Vajon ki lehet nyitni?");
                                }
                            }

                            //törd parancs

                            if (parancs.Contains("törd"))
                            {
                                if (parancs == "törd ablak") Console.WriteLine("Hezitálsz, hogy puszta kézzel betörd az ablakot,\n" +
                                    "de nem akarod az ország legszebb keze 2019 díjasát megsebezni.\n" +
                                    "Biztos van valahol valami, amivel belehet könnyen törni...");
                                if (parancs == "törd ablak feszítővas" && feszitovas)
                                    Console.WriteLine("Megragadod a feszítővasat és betöröd az ablak üvegét.\n" +
                                        " A szilánkok szerencsére nem sebeznek meg");
                                parancs_fut = true;
                                feszitovas = false;
                                ablak = true;

                            }

                            //egyéb szöveg

                            else if (!parancs_fut) Console.WriteLine("Próbáld összeszedni a gondolataidat!"); //végülis müködik, de messy af

                        }
                    }

                    //fürdőszoba

                    while (szoba == "fürdőszoba")
                    {
                        parancs_fut = false;
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
                            //nézd parancs

                            if (parancs == "nézd")
                            {
                                Console.WriteLine("A fürdőszobában találod magad. Az egykor még kék csempék már barnán mutatnak. \n" +
                                    "Egy kádon kívűl már semmi se található a szobában. Talán a kádban lehet valami...");
                                parancs_fut = true;
                            }
                            if (parancs == "nézd kád")
                            {
                                Console.WriteLine("Bele nézel a kádba, ami tele van fekete nyálkás dologgal. A kád jobb\n" +
                                    "oldalában fémből készült anyag mutatkozik. Belenyúlsz, hogy kivedd azt.\n" +
                                    "Egy feszítővas az!\n" +
                                    "Megtaláltad a feszítővasat.");
                                feszitovas = true;
                                parancs_fut = true;
                            }

                            //menj parancs
                            if (parancs == "menj kelet")
                            {
                                Console.WriteLine("Visszatértél a nappaliba.");
                                szoba = "nappali";
                                parancs_fut = true;
                            }

                            else if (!parancs_fut) Console.WriteLine("Próbáld összeszedni a gondolataidat!");
                        }
                    }
                }
                Console.WriteLine("grat");
            }
        }

    }
}

//oop nélkül
//ki lehet már játszani. ismert bugok:
//- fadobozt fellehet venni, ha zárva a szekrény
//- fürdőben kiírja, hogy "nézz körbe" hiába nézd a parancs
//- ablakot ugyanúgy belehet törni a szekrény eltolása nélkül
//- húzd szekrény parancsnál, "próbáld összeszedni a gondolataidat"
//- nyisd ablak parancsnál átvisz a fürdőbe
//- törd ablak feszítővas parancsnál nincsen szöveg
//- kiírja, az északos és a nem északos  verziót is amikor ablak=true +"próbáld össze..." 