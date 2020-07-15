using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;

namespace szabadulas_a_szobabol
{

    class Program
    {


        static void Main()
        {
            Targyak kulcs = new Targyak("kulcs", false, false, false, false);
            Targyak szekreny = new Targyak("szekrény", false, false, false, false);
            Targyak doboz = new Targyak("doboz", false, false, false, false);
            Targyak feszitovas = new Targyak("feszítővas", false, false, false, false);
            Targyak ajto = new Targyak("ajtó", false, false, false, false);
            Targyak kad = new Targyak("kád", false, false, false, false);
            Targyak ablak = new Targyak("ablak", false, false, false, false);

            Parancsok nezd = new Parancsok("nézd", true);
            Parancsok menj = new Parancsok("menj", false);
            Parancsok vedd_fel = new Parancsok("vedd fel", false);
            Parancsok huzd = new Parancsok("húzd", false);
            Parancsok nyisd = new Parancsok("nyisd", false);
            Parancsok tord = new Parancsok("törd", false);

            Iranyok eszak = new Iranyok("észak", false);
            Iranyok kelet = new Iranyok("kelet", false);
            Iranyok del = new Iranyok("dél", false);
            Iranyok nyugat = new Iranyok("nyugat", false);

            Szobak nappali = new Szobak("nappali", true, false);
            Szobak furdo = new Szobak("fürdőszoba", false, false);
            Szobak gyoztes = new Szobak("győztes", false, false);





            string parancs = " ";
            string[] inventory = new string[10];
            string felvett_targy = " ";

            void Raktarbovit()
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] == null)
                    {
                        inventory[i] = felvett_targy;
                        break;
                    }
                }
            }

            void Raktarmutatas()
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[0] != null)
                    {
                        if (inventory[i] != null)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        else break;
                    }
                    else
                    {
                        Console.WriteLine("Nincs nálad semmi!");
                        break;
                    }
                }
            }



            void Parancsbekeres()
            {
                Console.WriteLine("##########################");
                Console.Write("Mit szeretnél csinálni? -> ");
                parancs = Console.ReadLine();
                Console.WriteLine();
            }


            Console.WriteLine("Szabadulás a szobából");
            Console.WriteLine("\nEgy hideg padlón fekszel, és borzasztó fejfájásod van.\n" +
                "Nem tudod, hogyan kerültél ide, az utolsó emléked, hogy a város utcáin sétáltál,\n" +
                "amikor hirtelen hátulról megragadtak és kloroformos kendővel elkábítottak.\n" +
                "Felállsz majd a sötétben tapogatozva megtalálsz egy villanykapcsolót.\n" +
                "felkapcsolod, és utána látod, hogy egy régi, elhagyatott szobában találod magad.\n" +
                "(a következő parancsokat használhatod: menj, nézd, vedd fel, nyisd, húzd, törd)");

            //nappali

            while (!gyoztes.szobavan)
            {
                while (nappali.szobavan)
                {
                    Parancsbekeres();

                    if (parancs == "raktár")
                    {
                        Console.WriteLine("Ezek vannak a raktáradban: ");
                        Raktarmutatas();
                    }

                    if (!parancs.Contains(ajto.targynev))
                    {
                        ajto.interakcio = false;
                    }

                    //nézd

                    if (parancs == nezd.parancsnev)
                    {
                        if (!nappali.megnezett)
                        {
                            if (!eszak.mehet)
                            {
                                Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                        "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                        "Tőled nyugatra egy ajtót pillantasz meg.");
                                nappali.megnezett = true;
                                nyisd.mukodik = true;
                                vedd_fel.mukodik = true;
                                menj.mukodik = true;
                                huzd.mukodik = true;
                                tord.mukodik = true;
                                szekreny.interakcio = true;
                                szekreny.hasznalhato = true;
                                nyugat.mehet = true;
                            }
                            else

                                Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                        "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                        "Tőled nyugatra egy ajtót pillantasz meg.\n" +
                                        "Északra egy törött ablak található.");


                        }
                        else
                            Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                    "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                    "Tőled nyugatra egy ajtót pillantasz meg.");
                    }

                    //nyisd

                    if (parancs == nyisd.parancsnev + " " + szekreny.targynev && nyisd.mukodik)                                     //szekrény
                    {
                        if (szekreny.interakcio)
                        {
                            Console.WriteLine("Megpróbálod kinyitni a szekrényt. Kisebb erőfeszítés után az\n" +
                                    "ajtó kiugrik a helyéről. Az egyik polcon egy fadobozt pillantasz meg.");
                            doboz.interakcio = true;
                            szekreny.interakcio = false;
                            szekreny.hasznalt2 = true;

                        }
                        else if (szekreny.hasznalt2) Console.WriteLine("Már kinyitottad a szekrényt!");

                    }

                    if (parancs == nyisd.parancsnev + " " + ajto.targynev || parancs == nyisd.parancsnev + " " + ajto.targynev + " " + kulcs.targynev)  //ajtó                                                         //ajtó
                    {
                        if (ajto.interakcio)
                        {
                            if (kulcs.hasznalhato && nyisd.mukodik)
                            {
                                if (parancs == nyisd.parancsnev + " " + ajto.targynev + " " + kulcs.targynev)
                                {
                                    Console.WriteLine("A kulccsal kinyitod az ajtót,\n" +
                                            "és egy másik szobában találod magad.");
                                    nappali.szobavan = false;
                                    furdo.szobavan = true;
                                    ajto.interakcio = false;
                                    kulcs.hasznalhato = false;
                                    ajto.hasznalt = true;
                                    kulcs.hasznalt = true;
                                }
                                else if (parancs == nyisd.parancsnev + " " + ajto.targynev)
                                    Console.WriteLine("Megpróbálod lenyomni a kilincset, de az ajtó zárva marad\n" +
                                            "biztos egy kulcs kell hozzá...");
                            }
                            else if (ajto.hasznalt) Console.WriteLine("Már kinyitottad az ajtót! ");

                        }
                        else Console.WriteLine("Túl messze van ajtó, hogy csinálj vele bármit!");
                    }

                    if (parancs == nyisd.parancsnev + " " + doboz.targynev)                                                             //doboz
                    {
                        if (doboz.hasznalhato && nyisd.mukodik)
                        {
                            Console.WriteLine("Kinyitod a fadobozt.Egy ékszeres doboz az,\n" +
                                    "de nyaklánc helyett csak egy kicsi kulcsot találsz benne.\n" +
                                    "vajon mit nyithat?\n" +
                                    "Megtaláltad a kulcsot!");
                            doboz.hasznalhato = false;
                            kulcs.hasznalhato = true;
                            doboz.hasznalt = true;
                            felvett_targy = kulcs.targynev;
                            Raktarbovit();
                        }
                        else if (doboz.hasznalt) Console.WriteLine("Már kinyitottad a dobozt!");
                    }


                    if (parancs == nyisd.parancsnev + " " + ablak.targynev && ablak.interakcio && nyisd.mukodik)                        //ablak
                        Console.WriteLine("Megpróbálod kinyitni az ablakot, de beragadt.\n" +
                                "Hacsak valamivel be tudnád törni...");


                    //vedd fel

                    if (parancs == vedd_fel.parancsnev + " " + doboz.targynev && vedd_fel.mukodik)                                       //doboz
                    {

                        if (doboz.interakcio)
                        {
                            Console.WriteLine("Felvetted a dobozt.");
                            doboz.hasznalhato = true;
                            doboz.interakcio = false;
                            doboz.hasznalt2 = true;
                            felvett_targy = doboz.targynev;
                            Raktarbovit();
                        }
                        else if (doboz.hasznalt2) Console.WriteLine("Már felvetted a dobozt");
                    }


                    //húzd

                    if (parancs == huzd.parancsnev + " " + szekreny.targynev && huzd.mukodik)                                             //szekreny
                    {
                        if (szekreny.hasznalhato)
                        {

                            Console.WriteLine("Elhúzod a szekrényt. Mögötte egy ablak található! Vajon ki lehet nyitni?");
                            szekreny.hasznalhato = false;
                            ablak.interakcio = true;
                            szekreny.hasznalt = true;

                        }
                        else if (szekreny.hasznalt) Console.WriteLine("Már elhúztad a szekrényt!");
                    }

                    //törd

                    if (parancs == tord.parancsnev + " " + ablak.targynev || parancs == tord.parancsnev + " " + ablak.targynev + " " + feszitovas.targynev)   //ablak
                    {
                        if (ablak.interakcio && tord.mukodik)
                        {
                            if (parancs == tord.parancsnev + " " + ablak.targynev + " " + feszitovas.targynev)
                            {
                                Console.WriteLine("Megragadod a feszítővasat és betöröd az ablak üvegét.\n" +
                                        "A szilánkok szerencsére nem sebeznek meg");
                                ablak.interakcio = false;
                                feszitovas.hasznalhato = false;
                                eszak.mehet = true;
                                ablak.hasznalt = true;
                                feszitovas.hasznalt = true;
                            }

                            else Console.WriteLine("Hezitálsz, hogy puszta kézzel betörd az ablakot,\n" +
                                     "de nem akarod az ország legszebb keze 2019 díjasát megsebezni.\n" +
                                     "Biztos van valahol valami, amivel belehet könnyen törni...");
                        }
                        else if (ablak.hasznalt) Console.WriteLine("Már betörted az ablakot!");
                    }

                    //menj

                    if (parancs == menj.parancsnev + " " + nyugat.iranynev)                                                                 //nyugat
                    {
                        if (menj.mukodik && nyugat.mehet)
                        {
                            if (ajto.hasznalt)
                            {
                                Console.WriteLine("Visszamész a fürdőbe.");
                                furdo.szobavan = true;
                                nappali.szobavan = false;
                            }
                            else
                            {
                                Console.WriteLine("Oda mész az ajtóhoz.");
                                ajto.interakcio = true;
                            }

                        }
                    }


                    if (parancs == menj.parancsnev + " " + eszak.iranynev && menj.mukodik)
                    {
                        if (eszak.mehet)
                        {
                            Console.WriteLine("Megközelíted az ablakhoz és elkezdesz átmászni rajta.\n" +
                                "Szerencsére a lyuk van akkora, hogy karcolás nélkül át tudsz mászni rajta.");
                            nappali.szobavan = false;
                            gyoztes.szobavan = true;
                        }
                        else Console.WriteLine("Erre nem mehetsz!");
                    }


                }

                //fürdőszoba

                while (furdo.szobavan)
                {
                    Parancsbekeres();
                    Console.WriteLine("Ezek vannak a raktáradban: ");
                    if (parancs == "raktár") Raktarmutatas();

                    if (!furdo.megnezett)
                    {
                        nyisd.mukodik = false;
                        vedd_fel.mukodik = false;
                        menj.mukodik = false;
                    }

                    //nézd

                    if (parancs == nezd.parancsnev)
                    {
                        if (!furdo.megnezett)
                        {
                            Console.WriteLine("Egy kádon kívűl már semmi se található a szobában.Talán a kádban lehet valami...");
                            nyisd.mukodik = true;
                            vedd_fel.mukodik = true;
                            menj.mukodik = true;
                            furdo.megnezett = true;
                            kad.interakcio = true;
                            kelet.mehet = true;

                        }
                        else Console.WriteLine("Egy kádon kívűl már semmi se található a szobában.Talán a kádban lehet valami...");

                    }

                    if (parancs == nezd.parancsnev + " " + kad.targynev)
                    {
                        if (kad.interakcio)
                        {
                            Console.WriteLine("Bele nézel a kádba, ami tele van fekete nyálkás dologgal. A kád jobb\n" +
                                    "oldalában fémből készült anyag mutatkozik. Belenyúlsz, hogy kivedd azt.\n" +
                                    "Megtaláltad a feszítővast!");
                            kad.interakcio = false;
                            kad.hasznalt = false;
                            feszitovas.hasznalhato = true;
                            felvett_targy = feszitovas.targynev;
                            Raktarbovit();
                        }
                        else if (!kad.hasznalt) Console.WriteLine("Már megnézted a kádat!");
                    }

                    //menj

                    if (parancs == menj.parancsnev + " " + kelet.iranynev && kelet.mehet)
                    {
                        Console.WriteLine("Visszamentél a nappaliba.");
                        nappali.szobavan = true;
                        furdo.szobavan = false;
                    }
                }

            }
        }
    }
}