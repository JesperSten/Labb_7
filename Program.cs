namespace Labb_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välj uppgift:\n1: Uppgift 1\n2: Uppgift 2\n3: Uppgift 3");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                // UPPGIFT 1
                case "1":
                    // sjukhus
                    TreeNode hospital = new TreeNode("1", "Sjukhus", "Falu lasarett");

                    // avdelningar
                    TreeNode akuten = new TreeNode("2", "Avdelning", "Akuten");
                    TreeNode medicin = new TreeNode("3", "Avdelning", "Medicinavdelningen");

                    hospital.FirstChild = akuten;
                    akuten.NextSibling = medicin;


                    // rum akuten
                    TreeNode rum101 = new TreeNode("4", "rum", "rum 101");
                    TreeNode rum102 = new TreeNode("5", "rum", "rum 102");

                    akuten.FirstChild = rum101;
                    rum101.NextSibling = rum102;

                    // patienter rum 101
                    TreeNode mika = new TreeNode("6", "Patient", "Mika Niininen");
                    TreeNode saaid = new TreeNode("7", "Patient", "Saaid Geesey");

                    rum101.FirstChild = mika;
                    mika.NextSibling = saaid;

                    // patienter rum 102
                    TreeNode jesper = new TreeNode("8", "Patient", "Jesper Sten");

                    rum102.FirstChild = jesper;

                    // rum medicinavdelning
                    TreeNode rum201 = new TreeNode("9", "rum", "rum 201");

                    medicin.FirstChild = rum201;

                    // patient rum 201
                    TreeNode qadar = new TreeNode("10", "Patient", "Qadar Abdulle");

                    rum201.FirstChild = qadar;
                    Console.WriteLine("\nHierarki: Sjukhus -> Avdelning -> Rum -> Patient\n");
                    PreOrder(hospital, 0);
                    break;

                // UPPGIFT 2
                case "2":
                    Console.WriteLine("\nTidsbokningar i ordning:\n");

                    BookingNode root1 = null;

                    Console.WriteLine("______Sorterad inmatning_____");
                    root1 = Insert(root1, new DateTime(2024, 12, 1, 9, 30, 0), "Mika Niininen");
                    root1 = Insert(root1, new DateTime(2025, 6, 10, 10, 45, 0), "Saaid Geesey");
                    root1 = Insert(root1, new DateTime(2025, 6, 10, 11, 12, 0), "Jesper Sten");
                    root1 = Insert(root1, new DateTime(2025, 6, 10, 12, 25, 0), "Qadar Abdulle");

                    TraverseInOrder(root1);

                    Console.WriteLine("\n______Osorterad inmatning_____");
                    BookingNode root2 = null;

                    root2 = Insert(root2, new DateTime(2026, 12, 1, 9, 30, 0), "Mika Niininen");
                    root2 = Insert(root2, new DateTime(2023, 6, 10, 10, 45, 0), "Saaid Geesey");
                    root2 = Insert(root2, new DateTime(2025, 12, 10, 11, 12, 0), "Jesper Sten");
                    root2 = Insert(root2, new DateTime(2025, 3, 10, 12, 25, 0), "Qadar Abdulle");

                    TraverseInOrder(root2);

                    break;

                // UPPGIFT 3
                case "3":
                    DecisionNode root = new DecisionNode("Har du feber över 39 grader?", true);

                    DecisionNode breathing = new DecisionNode("Har du svårt att andas?", true);
                    DecisionNode throat = new DecisionNode("Har du ont i halsen?", true);

                    DecisionNode call112 = new DecisionNode("Ring 112 - AKUT!", false);
                    DecisionNode seekCare = new DecisionNode("Sök vård imorgon.", false);
                    DecisionNode rest = new DecisionNode("Vila och drick vatten.", false);
                    DecisionNode work = new DecisionNode("Gå och jobba.", false);

                    // Koppla ihop noderna
                    root.Yes = breathing;
                    root.No = throat;

                    breathing.Yes = call112;
                    breathing.No = seekCare;

                    throat.Yes = rest;
                    throat.No = work;

                    // Starta boten
                    RunDiagnosisBot(root);

                    break;
            }



        }

        // UPPGIFT 1 - PreOrder traversal

        static void PreOrder(TreeNode node, int level)
        {
            if (node == null)
                return;

            Console.WriteLine(new string('-', level * 2) + $"{node.Type}: {node.Name}");

            PreOrder(node.FirstChild, level + 1);

            PreOrder(node.NextSibling, level);
                
            
        }

        // UPPGIFT 2 - Binary sökträd för tidsbokningar
        static BookingNode Insert(BookingNode node, DateTime time, string patientName)
        {
            if (node == null)
            {
                return new BookingNode(time, patientName);
            }

            if (time < node.Time)
            {
                node.Left = Insert(node.Left, time, patientName);
            }

            else
            {
                node.Right = Insert(node.Right, time, patientName);
            }

            return node;

        }


        // In-order traversal för att visa bokningarna i tidsordning
        static void TraverseInOrder(BookingNode node)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left);

            Console.WriteLine($"{node.Time}: {node.PatientName}");

            TraverseInOrder(node.Right);
        }

        // UPPGIFT 3 - Diagnos-Bot
        static void RunDiagnosisBot(DecisionNode root)
        {
            DecisionNode current = root;

            Console.WriteLine("Välkommen till Diagnos-Boten");
            Console.WriteLine("============================");

            while (current.IsQuestion)
            {
                Console.Write(current.Text + " (j/n): ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "j")
                {
                    current = current.Yes;
                }
                else if (answer == "n")
                {
                    current = current.No;
                }
                else
                {
                    Console.WriteLine("Svara endast med j eller n.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("REKOMMENDATION: " + current.Text);
        }


    }
}
