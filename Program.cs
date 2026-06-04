namespace Labb_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // UPPGIFT 1

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

        }

        static void PreOrder(TreeNode node, int level)
        {
            if (node == null)
                return;

            Console.WriteLine(new string('-', level * 2) + $"{node.Type}: {node.Name}");

            PreOrder(node.FirstChild, level + 1);

            PreOrder(node.NextSibling, level);
                
            
        }

    }
}
