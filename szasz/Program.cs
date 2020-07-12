using System;
using System.Xml;

namespace szabadulas_a_szobabol
{


    class program
    {
        static void Main(string[] args)
        {
            targyak kulcs = new targyak("kulcs", false, false, false);
            targyak szekreny = new targyak("szekrény", false, false, false);
            targyak doboz = new targyak("doboz", false, false, false);
            targyak feszitovas = new targyak("feszítővas", false, false, false);
            targyak ajto = new targyak("ajtó", false, false, false);
            targyak kad = new targyak("kád", false, false, false);
            targyak ablak = new targyak("ablak", false, false, false);

            parancsok nezd = new parancsok("nézd", true);
            parancsok menj = new parancsok("menj", false);
            parancsok vedd_fel = new parancsok("vedd fel", false);
            parancsok huzd = new parancsok("húzd", false);
            parancsok nyisd = new parancsok("nyisd", false);
            parancsok tord = new parancsok("törd", false);

            iranyok eszak = new iranyok("észak", false);
            iranyok kelet = new iranyok("kelet", false);
            iranyok del = new iranyok("dél", false);
            iranyok nyugat = new iranyok("nyugat", false);

            szobak nappali = new szobak("nappali", true, false);
            szobak furdo = new szobak("fürdőszoba", false, false);
            szobak gyoztes = new szobak("győztes", false, false);


            Console.WriteLine("Szabadulás a szobából");
            Console.WriteLine("\nEgy hideg padlón fekszel, és borzasztó fejfájásod van.\n" +
                "Nem tudod, hogyan kerültél ide, az utolsó emléked, hogy a város utcáin sétáltál,\n" +
                "amikor hirtelen hátulról megragadtak és kloroformos kendővel elkábítottak.\n" +
                "Felállsz majd a sötétben tapogatozva megtalálsz egy villanykapcsolót.\n" +
                "felkapcsolod, és utána látod, hogy egy régi, elhagyatott szobában találod magad.\n" +
                "(a következő parancsokat használhatod: menj, nézd, vedd fel, nyisd, húzd, törd)");
            string parancs = " ";




            //nappali


            while (!gyoztes.szobavan)
            {
                while (nappali.szobavan)
                {
                    Console.WriteLine("##########################");
                    Console.Write("Mit szeretnél csinálni? -> ");
                    parancs = Console.ReadLine();
                    Console.WriteLine();
                    if (!parancs.Contains(ajto.targynev))
                    {
                        ajto.interakcio = false;
                    }

                    //nézd

                    if (parancs == nezd.parancsnev && !eszak.mehet)
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

                    if (parancs == nezd.parancsnev && eszak.mehet)
                        Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                "Tőled nyugatra egy ajtót pillantasz meg.\n" +
                                "Északra egy törött ablak található.");



                    //nyisd

                    if (!szekreny.interakcio && parancs == nyisd.parancsnev + " " + szekreny.targynev)
                        Console.WriteLine("Már kinyitottad a szekrényt!");

                    if (nyisd.mukodik && szekreny.interakcio && parancs == nyisd.parancsnev + " " + szekreny.targynev)
                    {
                        Console.WriteLine("Megpróbálod kinyitni a szekrényt. Kisebb erőfeszítés után az\n" +
                                "ajtó kiugrik a helyéről. Az egyik polcon egy fadobozt pillantasz meg.");
                        doboz.interakcio = true;
                        szekreny.interakcio = false;
                    }

                    if (parancs == nyisd.parancsnev + " " + ajto.targynev && nyisd.mukodik && ajto.interakcio)
                        Console.WriteLine("Megpróbálod lenyomni a kilincset, de az ajtó zárva marad\n" +
                                "biztos egy kulcs kell hozzá...");
                    if ((parancs == nyisd.parancsnev + " " + ajto.targynev + " " + kulcs.targynev) || (parancs == nyisd.parancsnev + " " + ajto.targynev) && !ajto.interakcio)
                        Console.WriteLine("Túl messze van ajtó, hogy csinálj vele bármit!");

                    if (parancs == nyisd.parancsnev + " " + ajto.targynev + " " + kulcs.targynev && (kulcs.hasznalt || ajto.hasznalt))
                        Console.WriteLine("Már kinyitottad az ajtót!");

                    if (nyisd.mukodik && ajto.interakcio && kulcs.hasznalhato && parancs == nyisd.parancsnev + " " + ajto.targynev + " " + kulcs.targynev)
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



                    if (parancs == nyisd.parancsnev + " " + doboz.targynev && doboz.hasznalt)
                        Console.WriteLine("Már kinyitottad a dobozt!");

                    if (parancs == nyisd.parancsnev + " " + doboz.targynev && doboz.hasznalhato && nyisd.mukodik)
                    {
                        Console.WriteLine("Kinyitod a fadobozt.Egy ékszeres doboz az,\n" +
                                "de nyaklánc helyett csak egy kicsi kulcsot találsz benne.\n" +
                                "vajon mit nyithat?\n" +
                                "Megtaláltad a kulcsot!");
                        doboz.hasznalhato = false;
                        kulcs.hasznalhato = true;
                        doboz.hasznalt = true;

                    }


                    if (parancs == nyisd.parancsnev + " " + ablak.targynev && ablak.interakcio && nyisd.mukodik)
                    {
                        Console.WriteLine("Megpróbálod kinyitni az ablakot, de beragadt.\n" +
                                "Hacsak valamivel be tudnád törni...");

                    }

                    //vedd fel

                    if (parancs == vedd_fel.parancsnev + " " + doboz.targynev && !doboz.interakcio && doboz.hasznalhato)
                        Console.WriteLine("Már felvetted a dobozt!");


                    if (parancs == vedd_fel.parancsnev + " " + doboz.targynev && doboz.interakcio && vedd_fel.mukodik)
                    {
                        Console.WriteLine("Felvetted a dobozt.");
                        doboz.hasznalhato = true;
                        doboz.interakcio = false;
                    }

                    //húzd
                    if (parancs == huzd.parancsnev + " " + szekreny.targynev && szekreny.hasznalt)
                        Console.WriteLine("Már elhúztad a szekrényt!");

                    if (parancs == huzd.parancsnev + " " + szekreny.targynev && szekreny.hasznalhato && huzd.mukodik)
                    {
                        Console.WriteLine("Elhúzod a szekrényt. Mögötte egy ablak található! Vajon ki lehet nyitni?");
                        szekreny.hasznalhato = false;
                        ablak.interakcio = true;
                        szekreny.hasznalt = true;
                    }

                    //törd

                    if (parancs == tord.parancsnev + " " + ablak.targynev + " " + feszitovas.targynev && (ablak.hasznalt || feszitovas.hasznalt))
                        Console.WriteLine("Már betörted az ablakot");


                    if (parancs == tord.parancsnev + " " + ablak.targynev && ablak.interakcio && tord.mukodik)
                    {
                        Console.WriteLine("Hezitálsz, hogy puszta kézzel betörd az ablakot,\n" +
                                "de nem akarod az ország legszebb keze 2019 díjasát megsebezni.\n" +
                                "Biztos van valahol valami, amivel belehet könnyen törni...");
                    }
                    if (parancs == tord.parancsnev + " " + ablak.targynev + " " + feszitovas.targynev && ablak.interakcio && tord.mukodik && feszitovas.hasznalhato)
                    {
                        Console.WriteLine("Megragadod a feszítővasat és betöröd az ablak üvegét.\n" +
                                "A szilánkok szerencsére nem sebeznek meg");
                        ablak.interakcio = false;
                        feszitovas.hasznalhato = false;
                        eszak.mehet = true;
                        ablak.hasznalt = true;
                        feszitovas.hasznalt = true;
                    }

                    //menj

                    if (parancs == menj.parancsnev + " " + nyugat.iranynev && nyugat.mehet && menj.mukodik && ajto.hasznalt)
                    {
                        Console.WriteLine("Visszamész a fürdőbe");
                        furdo.szobavan = true;
                        nappali.szobavan = false;
                    }

                    if (parancs == menj.parancsnev + " " + nyugat.iranynev && menj.mukodik && nyugat.mehet && !ajto.hasznalt)
                    {
                        Console.WriteLine("Oda mész az ajtóhoz.");
                        ajto.interakcio = true;
                    }

                    if (parancs == menj.parancsnev + " " + eszak.iranynev && menj.mukodik && eszak.mehet)
                    {
                        Console.WriteLine("Megközelíted az ablakhoz és elkezdesz átmászni rajta.\n" +
                            "Szerencsére a lyuk van akkora, hogy karcolás nélkül át tudsz mászni rajta");
                        nappali.szobavan = false;
                        gyoztes.szobavan = true;
                    }
                }

                while (furdo.szobavan)
                {
                    Console.WriteLine("##########################");
                    Console.Write("Mit szeretnél csinálni? -> ");
                    parancs = Console.ReadLine();
                    Console.WriteLine();
                    if (!furdo.megnezett)
                    {
                        nyisd.mukodik = false;
                        vedd_fel.mukodik = false;
                        menj.mukodik = false;
                    }

                    //nézd

                    if (parancs == nezd.parancsnev)
                    {
                        Console.WriteLine("Egy kádon kívűl már semmi se található a szobában.Talán a kádban lehet valami...");
                        nyisd.mukodik = true;
                        vedd_fel.mukodik = true;
                        menj.mukodik = true;
                        furdo.megnezett = true;
                        kad.interakcio = true;
                        kelet.mehet = true;
                    }

                    if (parancs == nezd.parancsnev + " " + kad.targynev && kad.interakcio)
                    {
                        Console.WriteLine("Bele nézel a kádba, ami tele van fekete nyálkás dologgal. A kád jobb\n" +
                                        "oldalában fémből készült anyag mutatkozik. Belenyúlsz, hogy kivedd azt.\n" +
                                        "Megtaláltad a feszítővast!");
                        kad.interakcio = false;
                        kad.hasznalt = false;
                        feszitovas.hasznalhato = true;
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
