using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MHLootTracker
{
    class BaseData
    {
        private List<Hero> heroes = new List<Hero>();
        private List<Villain> villains = new List<Villain>();
        private List<LootList> loot = new List<LootList>();

        public BaseData()
        {
            addHeroes();
            addVillians();
            addLoot();
        }

        private void addHeroes()
        {
            heroes.Add(Hero.AntMan);

            heroes.Add(Hero.BlackCat);
            heroes.Add(Hero.BlackPanther);
            heroes.Add(Hero.BlackWidow);
            heroes.Add(Hero.Blade);

            heroes.Add(Hero.Cable);
            heroes.Add(Hero.CaptainAmerica);
            heroes.Add(Hero.CaptainMarvel);
            heroes.Add(Hero.Colossus);
            heroes.Add(Hero.Cyclops);

            heroes.Add(Hero.Daredevil);
            heroes.Add(Hero.Deadpool);
            heroes.Add(Hero.DrDoom);
            heroes.Add(Hero.DrStrange);

            heroes.Add(Hero.Elektra);
            heroes.Add(Hero.EmmaFrost);

            heroes.Add(Hero.Gambit);
            heroes.Add(Hero.GhostRider);
            heroes.Add(Hero.GreenGoblin);

            heroes.Add(Hero.Hawkeye);
            heroes.Add(Hero.Hulk);
            heroes.Add(Hero.HumanTorch);

            heroes.Add(Hero.Iceman);
            heroes.Add(Hero.InvisibleWoman);
            heroes.Add(Hero.IronFist);
            heroes.Add(Hero.IronMan);

            heroes.Add(Hero.JeanGrey);
            heroes.Add(Hero.Juggernaut);

            heroes.Add(Hero.KittyPryde);

            heroes.Add(Hero.Loki);
            heroes.Add(Hero.LukeCage);

            heroes.Add(Hero.Magik);
            heroes.Add(Hero.Magneto);
            heroes.Add(Hero.MoonKnight);
            heroes.Add(Hero.MrFantastic);

            heroes.Add(Hero.Nightcrawler);
            heroes.Add(Hero.Nova);

            heroes.Add(Hero.Psylocke);
            heroes.Add(Hero.Punisher);

            heroes.Add(Hero.RocketRacoon);
            heroes.Add(Hero.Rogue);

            heroes.Add(Hero.ScarletWitch);
            heroes.Add(Hero.SheHulk);
            heroes.Add(Hero.SilverSurfer);
            heroes.Add(Hero.SpiderMan);
            heroes.Add(Hero.SquirrelGirl);
            heroes.Add(Hero.StarLord);
            heroes.Add(Hero.Storm);

            heroes.Add(Hero.Taskmaster);
            heroes.Add(Hero.Thing);
            heroes.Add(Hero.Thor);

            heroes.Add(Hero.Venom);
            heroes.Add(Hero.Vision);

            heroes.Add(Hero.WarMachine);
            heroes.Add(Hero.WinterSoldier);
            heroes.Add(Hero.Wolverine);

            heroes.Add(Hero.X23);

            heroes.Sort();
        }

        private void addVillians()
        {
            villains.Add(Villain.Shocker);
            villains.Add(Villain.DrOctopus);
            villains.Add(Villain.Taskmaster);
            villains.Add(Villain.Hood);
            villains.Add(Villain.Kingpin);
            villains.Add(Villain.Juggernaut);
            villains.Add(Villain.Magneto);
            villains.Add(Villain.Sinister);
            villains.Add(Villain.MODOK);
            villains.Add(Villain.Mandarin);
            villains.Add(Villain.DrDoom);
            villains.Add(Villain.Kurse);
        }

        private void addLoot()
        {
            LootList shockerLoot = new LootList();
            shockerLoot.associatedVillain = Villain.Shocker;
            shockerLoot.loot.Add(new Loot("Vibro-Shock Gauntlets", LootType.Unique));
            loot.Add(shockerLoot);

            LootList docOckLoot = new LootList();
            docOckLoot.associatedVillain = Villain.DrOctopus;
            docOckLoot.loot.Add(new Loot("Mechanical Arms of Doc Octopus", LootType.Unique));
            docOckLoot.loot.Add(new Loot("Octobot Controller", LootType.Unique));
            loot.Add(docOckLoot);

            LootList taskmasterLoot = new LootList();
            taskmasterLoot.associatedVillain = Villain.Taskmaster;
            taskmasterLoot.loot.Add(new Loot("Taskmaster's Fighting for Losers Guide", LootType.Artifact));
            loot.Add(taskmasterLoot);

            LootList hoodLoot = new LootList();
            hoodLoot.associatedVillain = Villain.Hood;
            hoodLoot.loot.Add(new Loot("Nisanti Boots", LootType.Unique));
            loot.Add(hoodLoot);

            LootList kingpinLoot = new LootList();
            kingpinLoot.associatedVillain = Villain.Kingpin;
            kingpinLoot.loot.Add(new Loot("White Suit Jacket", LootType.Artifact));
            kingpinLoot.loot.Add(new Loot("Ruby Topped Cane", LootType.Unique));
            kingpinLoot.loot.Add(new Loot("Vice", LootType.Runeword));
            loot.Add(kingpinLoot);

            LootList juggernautLoot = new LootList();
            juggernautLoot.associatedVillain = Villain.Juggernaut;
            juggernautLoot.loot.Add(new Loot("Advanced Circlet of Cyttorak", LootType.Artifact));
            juggernautLoot.loot.Add(new Loot("Black Tom's Shillelagh", LootType.Artifact));
            juggernautLoot.loot.Add(new Loot("Unstoppable Force", LootType.Runeword));
            loot.Add(juggernautLoot);

            LootList magnetoLoot = new LootList();
            magnetoLoot.associatedVillain = Villain.Magneto;
            magnetoLoot.loot.Add(new Loot("Magneto Was Right T-Shirt", LootType.Artifact));
            magnetoLoot.loot.Add(new Loot("Mask of Xorn", LootType.Unique));
            loot.Add(magnetoLoot);

            LootList sinisterLoot = new LootList();
            sinisterLoot.associatedVillain = Villain.Sinister;
            sinisterLoot.loot.Add(new Loot("Sinister's Diamond", LootType.Artifact));
            sinisterLoot.loot.Add(new Loot("Sinister's Bioengineered Cuirass", LootType.Unique));
            loot.Add(sinisterLoot);

            LootList modokLoot = new LootList();
            modokLoot.associatedVillain = Villain.MODOK;
            modokLoot.loot.Add(new Loot("Mental Focus Headband", LootType.Artifact));
            modokLoot.loot.Add(new Loot("Doomsday Chair", LootType.Unique));
            loot.Add(modokLoot);

            LootList mandarinLoot = new LootList();
            mandarinLoot.associatedVillain = Villain.Mandarin;
            mandarinLoot.loot.Add(new Loot("Arnim Zola's ESP Box", LootType.Artifact));
            loot.Add(mandarinLoot);

            LootList doomLoot = new LootList();
            doomLoot.associatedVillain = Villain.DrDoom;
            doomLoot.loot.Add(new Loot("Hand of Doom", LootType.Artifact));
            doomLoot.loot.Add(new Loot("Helm of Doom", LootType.Unique));
            doomLoot.loot.Add(new Loot("Latverian Monarch Cloak", LootType.Unique));
            loot.Add(doomLoot);

            LootList kurseLoot = new LootList();
            kurseLoot.associatedVillain = Villain.Kurse;
            kurseLoot.loot.Add(new Loot("Gem of the Kursed", LootType.Artifact));
            kurseLoot.loot.Add(new Loot("Mask of Algrim", LootType.Unique));
            loot.Add(kurseLoot);
        }

        public List<Hero> getHeroes()
        {
            return heroes;
        }

        public Hero getHero(int id) {
            return heroes[id];
        }

        public List<Villain> getVillains()
        {
            return villains;
        }

        public Villain getVillain(int id)
        {
            return villains[id];
        }

        public List<LootList> getLoot()
        {
            return loot;
        }

        public LootList getLoot(Villain v)
        {
            foreach (LootList l in loot){
                if (l.associatedVillain == v)
                {
                    return l;
                }
            }
            return null;
        } 

    }

    class LootList
    {
        public List<Loot> loot = new List<Loot>();
        public Villain associatedVillain;
    }

    class Loot
    {
        public String itemName;
        public LootType type;

        public Loot(String n, LootType t)
        {
            itemName = n;
            type = t;
        }
    }


    public static class Extensions
    {
        public static string toString(this Hero hero)
        {
            switch (hero) {
                case Hero.AntMan:
                    return "Ant-Man";

                case Hero.BlackCat:
                    return "Black Cat";
                case Hero.BlackPanther:
                    return "Black Panther";
                case Hero.BlackWidow:
                    return "Black Widow";
                case Hero.Blade:
                    return "Blade";

                case Hero.Cable:
                    return "Cable";
                case Hero.CaptainAmerica:
                    return "Captain America";
                case Hero.CaptainMarvel:
                    return "Captain Marvel";
                case Hero.Colossus:
                    return "Colossus";
                case Hero.Cyclops:
                    return "Cyclops";

                case Hero.Daredevil:
                    return "Daredevil";
                case Hero.Deadpool:
                    return "Deadpool";
                case Hero.DrDoom:
                    return "Dr. Doom";
                case Hero.DrStrange:
                    return "Dr. Strange";

                case Hero.Elektra:
                    return "Elektra";
                case Hero.EmmaFrost:
                    return "Emma Frost";

                case Hero.Gambit:
                    return "Gambit";
                case Hero.GhostRider:
                    return "Ghost Rider";
                case Hero.GreenGoblin:
                    return "Green Goblin";

                case Hero.Hawkeye:
                    return "Hawkeye";
                case Hero.Hulk:
                    return "Hulk";
                case Hero.HumanTorch:
                    return "Human Torch";

                case Hero.Iceman:
                    return "Iceman";
                case Hero.InvisibleWoman:
                    return "Invisible Woman";
                case Hero.IronFist:
                    return "Iron Fist";
                case Hero.IronMan:
                    return "Iron Man";

                case Hero.JeanGrey:
                    return "Jean Grey";
                case Hero.Juggernaut:
                    return "Juggernaut";

                case Hero.KittyPryde:
                    return "Kitty Pryde";

                case Hero.Loki:
                    return "Loki";
                case Hero.LukeCage:
                    return "Luke Cage";

                case Hero.Magik:
                    return "Magik";
                case Hero.Magneto:
                    return "Magneto";
                case Hero.MoonKnight:
                    return "Moon Knight";
                case Hero.MrFantastic:
                    return "Mr. Fantastic";

                case Hero.Nightcrawler:
                    return "Nightcrawler";
                case Hero.Nova:
                    return "Nova";

                case Hero.Psylocke:
                    return "Psylocke";
                case Hero.Punisher:
                    return "Punisher";

                case Hero.RocketRacoon:
                    return "Rocket Racoon";
                case Hero.Rogue:
                    return "Rogue";

                case Hero.ScarletWitch:
                    return "Scarlet Witch";
                case Hero.SheHulk:
                    return "She-Hulk";
                case Hero.SilverSurfer:
                    return "Silver Surfer";
                case Hero.SpiderMan:
                    return "Spider-Man";
                case Hero.SquirrelGirl:
                    return "Squirrel Girl";
                case Hero.StarLord:
                    return "Star-Lord";
                case Hero.Storm:
                    return "Storm";

                case Hero.Taskmaster:
                    return "Taskmaster";
                case Hero.Thing:
                    return "Thing";
                case Hero.Thor:
                    return "Thor";

                case Hero.Venom:
                    return "Venom";
                case Hero.Vision:
                    return "Vision";

                case Hero.WarMachine:
                    return "War Machine";
                case Hero.WinterSoldier:
                    return "Winter Soldier";
                case Hero.Wolverine:
                    return "Wolverine";

                case Hero.X23:
                    return "X-23";

                default:
                    return "Undefined Hero";
            }
}

        public static string toString(this Villain villain)
        {
            switch (villain) {
                case Villain.Shocker:
                    return "Shocker";
                case Villain.DrOctopus:
                    return "Dr. Octopus";
                case Villain.Taskmaster:
                    return "Taskmaster";
                case Villain.Hood:
                    return "Hood";
                case Villain.Kingpin:
                    return "Kingpin";
                case Villain.Juggernaut:
                    return "Juggernaut";
                case Villain.Magneto:
                    return "Magneto";
                case Villain.Sinister:
                    return "Sinister";
                case Villain.MODOK:
                    return "M.O.D.O.K.";
                case Villain.Mandarin:
                    return "Mandarin";
                case Villain.DrDoom:
                    return "Dr. Doom";
                case Villain.Kurse:
                    return "Kurse";
                default:
                    return "Undefined Villain";
            }
        }
    }

    public enum Hero
    {
        AntMan,

        BlackCat,
        BlackPanther,
        BlackWidow,
        Blade,

        Cable,
        CaptainAmerica,
        CaptainMarvel,
        Colossus,
        Cyclops,

        Daredevil,
        Deadpool,
        DrDoom,
        DrStrange,

        Elektra,
        EmmaFrost,

        Gambit,
        GhostRider,
        GreenGoblin,

        Hawkeye,
        Hulk,
        HumanTorch,

        Iceman,
        InvisibleWoman,
        IronFist,
        IronMan,

        JeanGrey,
        Juggernaut,

        KittyPryde,

        Loki,
        LukeCage,

        Magik,
        Magneto,
        MoonKnight,
        MrFantastic,

        Nightcrawler,
        Nova,

        Psylocke,
        Punisher,

        RocketRacoon,
        Rogue,

        ScarletWitch,
        SheHulk,
        SilverSurfer,
        SpiderMan,
        SquirrelGirl,
        StarLord,
        Storm,

        Taskmaster,
        Thing,
        Thor,

        Venom,
        Vision,

        WarMachine,
        WinterSoldier,
        Wolverine,

        X23
    }

    public enum Villain
    {
        Shocker, 
        DrOctopus,
        Taskmaster,
        Hood,
        Kingpin,
        Juggernaut,
        Magneto, 
        Sinister,
        MODOK,
        Mandarin,
        DrDoom,
        Kurse
    }

    


    public enum LootType
    {
        Unique,
        Artifact,
        Runeword
    }
}
