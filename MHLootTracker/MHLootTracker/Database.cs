using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace MHLootTracker
{
    class Database
    {
        public const int FALSE = 0;
        public const int TRUE = 1;

        public BaseData data;

        SQLiteConnection dbConnection;

       public Database()
        {
            bool newDatabase = false;

            data = new BaseData();

            if (!File.Exists("MH_Database.sqlite"))
            {
                SQLiteConnection.CreateFile("MH_Database.sqlite");
                newDatabase = true;
            }

            dbConnection = new SQLiteConnection("Data Source=MH_Database.sqlite;Version=3;");
            dbConnection.Open();

            if (newDatabase)
            {
                createHeroesTable(dbConnection);
                createLootTable(dbConnection);
                createVillainsTable(dbConnection);

                createRunsTable(dbConnection);
            }

            //testInitCreation(dbConnection);
            //testRunsTable(dbConnection);
       
        }

        private void testInitCreation(SQLiteConnection dbConnection)
        {
            Console.WriteLine("Loot\n");
            SQLiteCommand hereosCommand = new SQLiteCommand(
                "SELECT * FROM Loot", dbConnection);
            SQLiteDataReader reader = hereosCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"] + " " + reader["Type"] + " " + reader["Villain"]);
            }
        }

        private void testRunsTable(SQLiteConnection dbConnection)
        {
            string testInStr = "INSERT INTO Runs (Hero, Villain, Time, Date) " +
                "VALUES ('Gambit', 'Kingpin', '00:40', '2016-04-25'" +
                ")";
            SQLiteCommand testInCommand = new SQLiteCommand(testInStr, dbConnection);
            testInCommand.ExecuteNonQuery();

            SQLiteCommand countCommand = new SQLiteCommand("SELECT MAX(id) AS Count FROM Runs", dbConnection);
            SQLiteDataReader reader = countCommand.ExecuteReader();
            int currId = 0;
            while (reader.Read())
            {
                string temp = reader["Count"].ToString();
                currId = Int32.Parse(temp);
                Console.WriteLine("Id: " + currId);
            }

            SQLiteCommand getVillainCommand = new SQLiteCommand("SELECT Villain FROM Runs WHERE id = " + currId, dbConnection);
            reader = getVillainCommand.ExecuteReader();
            String villain = "";
            while (reader.Read())
            {
                villain = (string)reader["Villain"];
            }

            SQLiteCommand getLootCommand = new SQLiteCommand("SELECT Name FROM Loot WHERE Villain = '" + villain + "'", dbConnection);
            reader = getLootCommand.ExecuteReader();
            while (reader.Read())
            {
                string insertStr = "INSERT INTO RunLoot (RunID, ItemName, GotItem) " +
                    "VALUES (" + currId + ", '" + reader["Name"] + "', " + FALSE + ")";
                SQLiteCommand insertCommand = new SQLiteCommand(insertStr, dbConnection);
                insertCommand.ExecuteNonQuery();
            }


            SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM Runs", dbConnection);

            reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"] + " " + reader["Hero"] + " " + reader["Villain"] + " " + reader["Time"] + " " + 
                    reader["Date"]);
            }

            selectCommand = new SQLiteCommand("SELECT * FROM RunLoot", dbConnection);

            reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["RunID"] + " " + reader["ItemName"] + " " + reader["GotItem"]);
            }
        }

        public void displayRuns()
        {
            SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM Runs", dbConnection);
            SQLiteDataReader runReader;
            runReader = selectCommand.ExecuteReader();
            while (runReader.Read())
            {
                string outputStr = runReader["id"] + " " + runReader["Hero"] + " " + runReader["Villain"] + " " + runReader["Time"] + " " +
                    runReader["Date"];

                SQLiteCommand itemsCommand = new SQLiteCommand("SELECT ItemName, GotItem FROM RunLoot WHERE RunID = " + runReader["id"], dbConnection);
                SQLiteDataReader itemsReader = itemsCommand.ExecuteReader();

                string lootString = "";
                while (itemsReader.Read())
                {
                    string gotItem = "" + itemsReader["GotItem"];
                    if (Int32.Parse(gotItem) == TRUE)
                    {
                        lootString += " " + itemsReader["ItemName"] + ",";
                    }
                }

                if (lootString == "")
                {
                    lootString = " No loot dropped";
                }
                outputStr += lootString;

                Console.WriteLine(outputStr);
            }

            /*
            selectCommand = new SQLiteCommand("SELECT * FROM RunLoot", dbConnection);

            runReader = selectCommand.ExecuteReader();
            while (runReader.Read())
            {
                Console.WriteLine(runReader["RunID"] + " " + runReader["ItemName"] + " " + runReader["GotItem"]);
            }
            */
        }

        private void createHeroesTable(SQLiteConnection dbConnection)
        {
            string createTableString =
                "CREATE TABLE Heroes ( " +
                "Name TEXT " +
                ")";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableString, dbConnection);
            createTableCommand.ExecuteNonQuery();

            List<Hero> heroes = data.getHeroes();
            foreach(Hero h in heroes)
            {
                string addHeroString =
                    "INSERT INTO Heroes (Name) VALUES ( '" + makeStringFitForSQL(h.toString()) + "' )";
                SQLiteCommand addHeroCommand = new SQLiteCommand(addHeroString, dbConnection);
                addHeroCommand.ExecuteNonQuery();
            }
        }

        private void createVillainsTable(SQLiteConnection dbConnection)
        {
            string createTableString =
                "CREATE TABLE Villains ( " +
                "Name TEXT " +
                ")";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableString, dbConnection);
            createTableCommand.ExecuteNonQuery();

            List<Villain> villains = data.getVillains();
            foreach (Villain v in villains)
            {
                string addVillainString =
                    "INSERT INTO Villains (Name) VALUES ( '" + makeStringFitForSQL(v.toString()) + "' )";
                SQLiteCommand addVillainCommand = new SQLiteCommand(addVillainString, dbConnection);
                addVillainCommand.ExecuteNonQuery();
            }
        }

        private void createLootTable(SQLiteConnection dbConnection)
        {
            string createTableString =
                "CREATE TABLE Loot ( " +
                "Name TEXT, Type TEXT, Villain TEXT " +
                ")";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableString, dbConnection);
            createTableCommand.ExecuteNonQuery();

            List<LootList> loot = data.getLoot();
            foreach (LootList lList in loot)
            {
                foreach(Loot l in lList.loot) {
                    string addLootString =
                    "INSERT INTO Loot (Name, Type, Villain) VALUES ( '" + makeStringFitForSQL(l.itemName) + "', '" + makeStringFitForSQL(l.type.ToString()) + "', '" + makeStringFitForSQL(lList.associatedVillain.toString()) + "' )";
                    SQLiteCommand addLootCommand = new SQLiteCommand(addLootString, dbConnection);
                    addLootCommand.ExecuteNonQuery();
                }
            }
        }

        private void createRunsTable(SQLiteConnection dbConnection)
        {
            // Hero
            // Villain
            // Time taken for run
            // %RIF
            // Date
            // Run id

            // SELECT DATE('now')
            // for current date

            // Date should be formatted like
            // YYYY-MM-DD
            // to be consistant with sqlite date formats
            string createTableString =
                "CREATE TABLE Runs ( " +
                "id INTEGER PRIMARY KEY," + 
                "Hero TEXT," +
                "Villain TEXT NOT NULL," +
                "Time TEXT," + 
                "RIF INTEGER DEFAULT 0," + 
                "Date TEXT" +
                ")";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableString, dbConnection);
            createTableCommand.ExecuteNonQuery();

            // Run Items table
            // Run id
            // Item
            // Did it drop?

            createTableString =
                "CREATE TABLE RunLoot (" +
                "RunID INTEGER NOT NULL, " +
                "ItemName TEXT," +
                "GotItem INTEGER DEFAULT " + FALSE +
                ")";
            createTableCommand = new SQLiteCommand(createTableString, dbConnection);
            createTableCommand.ExecuteNonQuery();
        }

        string makeStringFitForSQL(string strIn)
        {
            string strOut = strIn;

            strOut = strOut.Replace("'", "''");

            return strOut;
        }

        public void addRun(Hero h, Villain v, string time, DateTime date, List<bool> drops)
        {
            string runString = "INSERT INTO Runs (Hero, Villain, Time, Date) VALUES ("; 
            runString += "'" + makeStringFitForSQL(h.toString()) + "', ";
            runString += "'" + makeStringFitForSQL(v.toString()) + "', ";
            runString += "'" + makeStringFitForSQL(time) + "', ";
            string d = date.Date.ToString("yyy-MM-dd");
            runString += "'" + makeStringFitForSQL(d) + "'";
            runString += ")";

            SQLiteCommand testInCommand = new SQLiteCommand(runString, dbConnection);
            testInCommand.ExecuteNonQuery();

            SQLiteCommand countCommand = new SQLiteCommand("SELECT MAX(id) AS Count FROM Runs", dbConnection);
            SQLiteDataReader reader = countCommand.ExecuteReader();
            int currId = 0;
            while (reader.Read())
            {
                string temp = reader["Count"].ToString();
                currId = Int32.Parse(temp);
                Console.WriteLine("Id: " + currId);
            }

            SQLiteCommand getLootCommand = new SQLiteCommand("SELECT Name FROM Loot WHERE Villain = '" + makeStringFitForSQL(v.toString()) + "'", dbConnection);
            reader = getLootCommand.ExecuteReader();
            int itemNum = 0;
            while (reader.Read())
            {
                string insertStr = "";
                if (itemNum < drops.Count())
                {
                    insertStr = "INSERT INTO RunLoot (RunID, ItemName, GotItem) " +
                        "VALUES (" + currId + ", '" + reader["Name"] + "', ";
                    if (drops[itemNum])
                    {
                        insertStr += TRUE;
                    }
                    else
                    {
                        insertStr += FALSE;
                    }
                    insertStr += ")";
                } else
                {
                    insertStr = "INSERT INTO RunLoot (RunID, ItemName, GotItem) " +
                        "VALUES (" + currId + ", '" + "Invalid item" + "', -1)";
                }

                SQLiteCommand insertCommand = new SQLiteCommand(insertStr, dbConnection);
                insertCommand.ExecuteNonQuery();

                itemNum++;
            }
        }

    }
}
